using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using course.manager.webapi.Interfaces;
using LamarCodeGeneration.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;

namespace student.manager.webapi.Services
{
    public class CourseService : ICourseService
    {
        private readonly DatabaseContext _context;
        private readonly ICourseSubjectService _service;

        public CourseService(DatabaseContext ctx, ICourseSubjectService service)
        {
            _context = ctx;
            _service = service;
        }

        public async Task<Course> Create(Course course)
        {
            if (course.CourseId != 0)
                throw new BadRequestException("Um novo registro não pode conter um ID diferente de zero!");

            bool courseExists =
                await _context.Courses.AsQueryable().AnyAsync(c => c.Name.ToLower() == course.Name.ToLower());

            if (courseExists)
                throw new BadRequestException("Um curso com este nome já existe!");

            if (course.Subjects.IsNull() || !course.Subjects.Any())
                throw new BadRequestException("Não é possível adicionar um curso sem nenhuma matéria!");

            var subjects = course.Subjects;
            course.Subjects = null;

            using var transaction = await _context.Database.BeginTransactionAsync();
            long courseId = 0;
            try
            {
                await _context.Courses.AddAsync(course);
                _context.SaveChanges();

                var createdCourse = await _context.Courses.AsQueryable().FirstAsync(c => c.Name.ToLower() == course.Name.ToLower());
                courseId = createdCourse.CourseId;

                foreach (var subject in subjects)
                {
                    _ = await _service.Create(createdCourse.CourseId, subject.SubjectId);
                }

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                await transaction.RollbackAsync();
                //rethrow to controller
                throw e;
            }

            return await Find(courseId);
        }

        public async Task<bool> Delete(long courseId)
        {
            if (courseId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Course course = await Find(courseId);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Course> Find(long courseId)
        {
            if (courseId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Course course =
                await _context.Courses
                    .Include(c => c.Subjects)
                    .FirstOrDefaultAsync(c => c.CourseId == courseId);

            if (course.IsNull())
                throw new NotFoundException("Curso não encontrado");

            return course;
        }

        public async Task<bool> Update(Course course)
        {
            if (course.CourseId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Course createdCourse = await Find(course.CourseId);

            if (course.Subjects.IsNull() || !course.Subjects.Any())
                throw new BadRequestException("Não é possível atualizar um curso sem nenhuma matéria!");

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                createdCourse.Name = course.Name;

                var linkedSubjects = createdCourse.Subjects;

                createdCourse.Subjects = new List<Subject>();

                /* Vincula as novas matérias ao curso */
                foreach (var subject in course.Subjects)
                {
                    if (linkedSubjects.Any(x => x.SubjectId == subject.SubjectId))
                        continue;

                    _ = await _service.Create(createdCourse.CourseId, subject.SubjectId);
                }

                /* Remove as matérias não enviadas */
                foreach (var subject in linkedSubjects)
                {
                    if (course.Subjects.Any(x => x.SubjectId == subject.SubjectId)) continue;

                    _ = await _service.Delete(course.CourseId, subject.SubjectId);
                }

                _context.Entry(createdCourse).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                await transaction.RollbackAsync();
                //rethrow to controller
                throw e;
            }

            return true;
        }
    }
}

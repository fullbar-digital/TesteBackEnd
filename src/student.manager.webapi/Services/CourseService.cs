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
                throw new BadRequestException("Um novo registro não pode conter um ID diferente de zero.");

            BadRequestException.ThrowIfNotEmpty(await VerifyInstanceData(course));

            var subjects = course.Subjects;
            course.Subjects = null;

            using var transaction = await _context.Database.BeginTransactionAsync();
            long courseId = 0;
            try
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                var createdCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Name.ToLower() == course.Name.ToLower());
                courseId = createdCourse.CourseId;

                foreach (var subject in subjects)
                {
                    _ = await _service.Create(createdCourse.CourseId, subject.SubjectId);
                }

                await _context.SaveChangesAsync(true);
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
                throw new BadRequestException("Informe um número maior que zero.");

            Course course = await Find(courseId);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Course> Find(long courseId)
        {
            if (courseId <= 0)
                throw new BadRequestException("Informe um número maior que zero.");

            Course course =
                await _context.Courses
                    .Include(c => c.Subjects)
                    .Include(c => c.CourseSubjects)
                    .FirstOrDefaultAsync(c => c.CourseId == courseId);

            if (course.IsNull())
                throw new NotFoundException("Curso não encontrado");

            return course;
        }

        public async Task<bool> Update(Course course)
        {
            if (course.CourseId <= 0)
                throw new BadRequestException("O ID do curso a ser atualizado deve ser maior que zero.");

            BadRequestException.ThrowIfNotEmpty(await VerifyInstanceData(course));

            Course createdCourse = await Find(course.CourseId);

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                createdCourse.Name = course.Name;

                /* Vincula as novas matérias ao curso */
                foreach (var subject in course.Subjects)
                {
                    if (createdCourse.Subjects.Any(x => x.SubjectId == subject.SubjectId))
                        continue;

                    _ = await _service.Create(createdCourse.CourseId, subject.SubjectId, transaction);
                }

                var subjectsToBeRemoved = new List<long>();
                /* Remove as matérias não enviadas */
                foreach (var subject in createdCourse.Subjects)
                {
                    if (course.Subjects.Any(x => x.SubjectId == subject.SubjectId)) continue;

                    _ = await _service.Delete(course.CourseId, subject.SubjectId, transaction);
                    subjectsToBeRemoved.Add(subject.SubjectId);
                }

                createdCourse.Subjects = createdCourse.Subjects
                                                .Where(sub => !subjectsToBeRemoved.Contains(sub.SubjectId))
                                                .ToList();

                _context.Entry(createdCourse).State = EntityState.Modified;
                await _context.SaveChangesAsync(true);

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

        public async Task<string> VerifyInstanceData(Course course)
        {
            string errorMessage = "";

            if (course.Subjects.IsNull() || !course.Subjects.Any())
                errorMessage += "Não é possível atualizar um curso sem nenhuma matéria.\n";
            else
            {
                foreach (var subject in course.Subjects)
                {
                    if (!await _context.Subjects.AnyAsync(x => x.SubjectId == subject.SubjectId))
                        errorMessage += string.Format("Não é possível encontrar uma matéria com o ID {0}.\n", subject.SubjectId);
                }
            }

            if (await _context.Courses.CountAsync() != 0)
            {
                Course courseWithSameName = null;
                await _context.Courses.FirstOrDefaultAsync(c => c.Name.ToLower() == course.Name.ToLower());

                if (!courseWithSameName.IsNull() && courseWithSameName.CourseId != course.CourseId)
                    errorMessage += string.Format("O curso {0} já existe.\n", course.Name);
            }

            return errorMessage;
        }
    }
}

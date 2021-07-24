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
using student.manager.webapi.Models;

namespace student.manager.webapi.Services
{
    public class CourseService : ICourseService
    {
        private readonly DatabaseContext _context;

        public CourseService(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public async Task<Course> Create(Course course)
        {
            if (course.CourseId != 0)
                throw new BadRequestException("Um novo registro não pode conter um ID diferente de zero!");
            
            bool courseExists =
                await _context.Courses.AsQueryable().AnyAsync(c => c.Name.ToLower() == course.Name.ToLower());
            
            if (courseExists)
                throw new BadRequestException("Um curso com este nome já existe!");


            await _context.Courses.AddAsync(course);
            _context.SaveChanges();

            return await _context.Courses.AsQueryable().FirstAsync(c => c.Name.ToLower() == course.Name.ToLower());
        }

        public async Task<bool> Delete(long courseId)
        {
            if(courseId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Course course =
                await _context.Courses.FindAsync(courseId);

            if (course.IsNull())
                throw new NotFoundException("Curso não encontrado");


            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Course> Find(long courseId)
        {
            if(courseId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Course course =
                await _context.Courses.FindAsync(courseId);

            if (course.IsNull())
                throw new NotFoundException("Curso não encontrado");

            return course;
        }

        public async Task<bool> Update(Course course)
        {
            if(course.CourseId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Course createdCourse =
                await _context.Courses.FindAsync(course.CourseId);

            if (createdCourse.IsNull())
                throw new NotFoundException("Curso não encontrado, portanto não pode ser atualizado!");
            
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

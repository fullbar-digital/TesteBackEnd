using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Entities;
using Template.Api.ApplicationCore.Intefaces.Repositories;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.ApplicationCore.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IRepository<Student> repository, IStudentRepository studentRepository) : base(repository)
        {
            _studentRepository = studentRepository;
        }
        
        public override async Task<IQueryable<Student>> FindAsync(Expression<Func<Student, bool>> expression)
        {
            return (await GetAllAsync()).Where(expression).AsNoTracking();
        }

        public async override Task<IQueryable<Student>> GetAllAsync()
        {
            var result = (await base.GetAllAsync())
                .Include(s => s.CourseSubjectStudent)
                    .ThenInclude(s => s.CourseSubject)
                    .ThenInclude(s => s.Course)
                .AsNoTracking();

            return result.Select(s => new Student()
            {
                StudentId = s.StudentId,
                Name = s.Name,
                RA = s.RA,
                Period = s.Period,
                Photo = s.Photo,
                Status = s.Status,
                CourseSubjectStudent = s.CourseSubjectStudent.Select(ss => new CourseSubjectStudent()
                {
                    CourseSubjectStudentId = ss.CourseSubjectStudentId,
                    CourseSubjectId = ss.CourseSubjectId,
                    CourseSubject = ss.CourseSubject,
                    StudentId = ss.StudentId,
                    Grade = ss.Grade,
                    Status = ss.Grade > ss.CourseSubject.MinimumGrade
                })
            });
        }

        public override async Task<Student> GetByIdAsync(int id)
        {
            return (await GetAllAsync()).FirstOrDefault(s => s.StudentId == id);
        }

        public override async Task<int> UpdateAsync(Student student)
        {
            var result = await GetByIdAsync(student.StudentId);
            if (result is null)
                return 0;

            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var student = await base.GetByIdAsync(id);
            if (student is null)
                return 0;

            return await base.DeleteAsync(student);
        }
    }
}

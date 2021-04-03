using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Commands.Queries;
using App.Domain.Infra.Contexts;
using App.Domain.Models;
using App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Infra.Respositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _appContext;
        public StudentRepository(ApplicationContext AppContext)
        {
            _appContext = AppContext;
        }
        public void AddStudent(Student student)
        {
            _appContext.students.Add(student);
            _appContext.SaveChanges();
        }

        public void DeleteStudent(Student Student)
        {
            _appContext.students.Remove(Student);
            _appContext.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _appContext.students.Include(x => x.StudentSubjects).ToList();
        }

        public List<Student> GetByFilter(GetStudentsQuery query)
        {
            IQueryable<Student> q = _appContext.students;
            
            if (query.CourseId != null) {
                q = q.Where(s => s.CourseId == query.CourseId);
            }

            if (query.Name != null) {
                q = q.Where(s => s.Name == query.Name);
            }

            if (query.Register != null) {
                q = q.Where(s => s.Register == query.Register);
            }

            if (query.Period != null) {
                q = q.Where(s => s.Period == query.Period);
            }

            if (query.Status != null) {
                q = q.Where(s => s.Status == query.Status);
            }

            return q.ToList();
        }

        public Student GetById(Guid Id)
        {
            return _appContext.students
                                      .AsNoTracking()
                                      .Where(x => x.Id == Id)
                                      .FirstOrDefault();

        }
        public void UpdateStudent(Student Student)
        {
            _appContext.Entry(Student).State = EntityState.Modified;
            _appContext.SaveChanges();
        }
    }
}
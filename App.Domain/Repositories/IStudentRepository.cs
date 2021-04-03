using System;
using System.Collections.Generic;
using App.Domain.Commands.Queries;
using App.Domain.Models;

namespace App.Domain.Repositories
{
    public interface IStudentRepository
    {
        Student GetById(Guid Id);

        List<Student> GetAll();
        void AddStudent(Student student);
        void DeleteStudent(Student student);
        void UpdateStudent(Student student);
        List<Student> GetByFilter(GetStudentsQuery query);

    }
}
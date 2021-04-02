using System;
using System.Collections.Generic;
using App.Domain.Models;

namespace App.Domain.Repositories
{
    public interface IStudentSubjectRepository
    {
        List<StudentSubject> GetById(Guid Id);
    }
}
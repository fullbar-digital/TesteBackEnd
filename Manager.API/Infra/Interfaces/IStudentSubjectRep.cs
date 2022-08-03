using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IStudentSubjectRep : IBaseRep<StudentSubject>
    {
        Task<List<StudentSubject>> ListSubjects(int codestudent);
        Task<List<StudentSubject>> ListStudentForStatus(string status);
        Task<StudentSubject> ListForStudentSubject(int codestudent, int codesubject);
    }
}

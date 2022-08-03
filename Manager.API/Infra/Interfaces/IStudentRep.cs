using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IStudentRep : IBaseRep<Student>
    {
        Task<List<Student>> StudentForName(string name);
        Task<Student> StudentForRa(string ra);
        Task<List<Student>> StudentForCourse(int code);
    }
}

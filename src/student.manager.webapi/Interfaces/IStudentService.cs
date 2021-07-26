using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student.manager.webapi.Models;

namespace student.manager.webapi.Interfaces
{
    public interface IStudentService
    {
        Task<Student> Create(Student student);
        Task<bool> Delete(string academicRecord);
        Task<bool> Update(Student student);
        Task<Student> Find(string academicRecord);
        Task<IEnumerable<Student>> FindAny(string academicRecord = "", string name = "", long courseId = 0, string status = "");
        Task<string> VerifyInstanceData(Student student);
    }
}

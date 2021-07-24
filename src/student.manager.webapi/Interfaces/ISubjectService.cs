using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student.manager.webapi.Models;

namespace student.manager.webapi.Interfaces
{
    public interface ISubjectService
    {
        Task<Subject> Create(Subject subject);
        Task<bool> Delete(long subjectId);
        Task<bool> Update(Subject subject);
        Task<Subject> Find(long subjectId);
    }
}

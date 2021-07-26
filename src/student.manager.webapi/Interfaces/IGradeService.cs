using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student.manager.webapi.Models;

namespace grade.manager.webapi.Interfaces
{
    public interface IGradeService
    {
        Task<Grade> Create(Grade grade);
        Task<bool> Delete(long id);
        Task<bool> Update(Grade grade);
        Task<Grade> Find(long id);
        Task<string> VerifyInstanceData(Grade grade);
    }
}

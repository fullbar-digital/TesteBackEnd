using Microsoft.EntityFrameworkCore.Storage;
using student.manager.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.manager.webapi.Interfaces
{
    public interface ICourseSubjectService
    {
        Task<CourseSubject> Find(long courseId, long subjectId);
        Task<bool> Create(long courseId, long subjectId, IDbContextTransaction transaction = null);
        Task<bool> Delete(long courseId, long subjectId, IDbContextTransaction transaction = null);
    }
}

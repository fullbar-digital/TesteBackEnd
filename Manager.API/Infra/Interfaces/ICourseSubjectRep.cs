using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ICourseSubjectRep : IBaseRep<CourseSubject>
    {
        Task<CourseSubject> CourseForSubject(CourseSubject coursesubject);
        Task<List<CourseSubject>> ForCourse(int coursecode);
        Task<List<CourseSubject>> ForSubject(int subjectcode);
    }
}

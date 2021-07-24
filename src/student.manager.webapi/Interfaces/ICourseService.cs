using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student.manager.webapi.Models;

namespace course.manager.webapi.Interfaces
{
    public interface ICourseService
    {
        Task<Course> Create(Course course);
        Task<bool> Delete(long courseId);
        Task<bool> Update(Course course);
        Task<Course> Find(long courseId);
    }
}

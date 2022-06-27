using Template.Api.ApplicationCore.Entities;
using Template.Api.ApplicationCore.Intefaces.Repositories;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.ApplicationCore.Services
{
    public class CourseSubjectStudentService : BaseService<CourseSubjectStudent>, ICourseSubjectStudentService
    {
        public CourseSubjectStudentService(IRepository<CourseSubjectStudent> repository) : base(repository)
        {

        }
    }
}
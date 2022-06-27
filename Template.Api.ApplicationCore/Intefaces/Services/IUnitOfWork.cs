using System;

namespace Template.Api.ApplicationCore.Intefaces.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentService Students { get; }
        ICourseSubjectStudentService CourseSubjectStudentService { get; }
        int Complete();
    }
}
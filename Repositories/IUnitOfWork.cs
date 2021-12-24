using Domain.Entities;

using Repositories.Core;

namespace Repositories
{
    public interface IUnitOfWork
    {
        IDefaultRepository<Course> CourseRepository { get; }
        SchoolReportRepository SchoolReportRepository { get; }
        StudentRepository StudentRepository { get; }
        IDefaultRepository<Subject> SubjectRepository { get; }

        void Commit();
        void Dispose();
    }
}

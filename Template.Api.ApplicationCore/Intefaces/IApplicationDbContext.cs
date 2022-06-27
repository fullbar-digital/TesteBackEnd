using Microsoft.EntityFrameworkCore;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Intefaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<CourseSubjectStudent> CourseSubjectStudents { get; set; }
    }
}
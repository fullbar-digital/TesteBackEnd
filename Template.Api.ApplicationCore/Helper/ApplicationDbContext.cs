using Microsoft.EntityFrameworkCore;
using Template.Api.ApplicationCore.Builders;
using Template.Api.ApplicationCore.Entities;

namespace Template.Api.ApplicationCore.Intefaces
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StudentMap(modelBuilder.Entity<Student>());
            new CourseMap(modelBuilder.Entity<Course>());
            new CourseSubjectMap(modelBuilder.Entity<CourseSubject>());
            new CourseSubjectStudentMap(modelBuilder.Entity<CourseSubjectStudent>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CourseSubjects { get; set; }
        public DbSet<CourseSubjectStudent> CourseSubjectStudents { get; set; }
    }
}

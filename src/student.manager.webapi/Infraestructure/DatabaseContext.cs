using Microsoft.EntityFrameworkCore;
using student.manager.webapi.Models;

namespace student.manager.webapi.Infraestructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* Configura a relação n:n entre curso e matérias. */
            builder
                .Entity<Course>()
                .HasMany(p => p.Subjects)
                .WithMany(p => p.Courses)
                .UsingEntity<CourseSubject>(
                    c => c
                        .HasOne(n => n.Subject)
                        .WithMany(n => n.CourseSubjects)
                        .HasForeignKey(n => n.SubjectId)
                        .OnDelete(DeleteBehavior.Cascade),
                    c => c
                        .HasOne(n => n.Course)
                        .WithMany(n => n.CourseSubjects)
                        .HasForeignKey(n => n.CourseId)
                        .OnDelete(DeleteBehavior.Cascade),
                    c =>
                    {
                        c.Property(p => p.CreateDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        c.HasKey(k => new { k.CourseId, k.SubjectId });
                    }
                );

            base.OnModelCreating(builder);
        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<CourseSubject> CourseSubjects { get; set; }
    }
}

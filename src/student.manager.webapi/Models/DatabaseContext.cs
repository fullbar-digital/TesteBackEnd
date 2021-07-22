using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace student.manager.webapi.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
                .HasMany(p => p.Grades)
                .WithOne(p => p.Course)
                .HasForeignKey(p => p.CourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
            base.OnModelCreating(builder);
        }

        
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infra.Mapping;

namespace Infra.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseSubject> CourseSubject { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentSubject> StudentSubject { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SubjectMaps());
            builder.ApplyConfiguration(new CourseMap());
            builder.ApplyConfiguration(new CourseSubjectMap());
            builder.ApplyConfiguration(new StudentMap());
            builder.ApplyConfiguration(new StudentSubjectMap());


            //NxN
            builder.Entity<CourseSubject>()
                .HasKey(x => new { x.CourseId, x.SubjectId });

            builder.Entity<CourseSubject>()
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseSubject)
                .HasForeignKey(x => x.CourseId);

            builder.Entity<CourseSubject>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.CourseSubject)
                .HasForeignKey(x => x.SubjectId);



            builder.Entity<StudentSubject>()
                .HasKey(x => new { x.StudentId, x.SubjectId, x.Code });

            builder.Entity<StudentSubject>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.StudentId);

            builder.Entity<StudentSubject>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.StudentSubject)
                .HasForeignKey(x => x.SubjectId);

          

            //1xN
            builder.Entity<Student>()
                .HasOne(x => x.Course)
                .WithMany(x => x.Students);
            
        }
    }
}

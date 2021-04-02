
using App.Domain.Models;
using App.Domain.Infra.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Domain.Infra.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());


            var courseIdDevelopment = Guid.NewGuid();
            var courseIdEgineering = Guid.NewGuid();
            var courseIdBiology = Guid.NewGuid();
            var studentId = Guid.NewGuid();


            var subjects = new Subject[] {
                new Subject{Name="Phisics", MinAverageApproval=7.1, CourseId=courseIdDevelopment},
                new Subject{Name="Math", MinAverageApproval=7.1, CourseId=courseIdDevelopment},
                new Subject{Name="HealthCare", MinAverageApproval=7.1, CourseId=courseIdBiology},
                new Subject{Name="OOP", MinAverageApproval=7.1, CourseId=courseIdEgineering},
            };

            var students = new Student[] {
                new Student{
                    Id = studentId,
                    Name="Matheus Angelo",
                    Register="D06JGF", Period="Night",
                    CourseId=courseIdDevelopment,
                    Photo="https://via.placeholder.com/150",
                    Status="Active"
                },
            };


            var courses = new Course[] {
                new Course{Id= courseIdDevelopment, Name="IT Development"},
                new Course{Id= courseIdEgineering, Name="Software Egineering"},
                new Course{Id= courseIdBiology, Name="Biology"}
            };

            var studentSubject = new StudentSubject[] {
                new StudentSubject{
                    StudentId = studentId,
                    SubjectId = subjects[0].Id,
                    Average = 8.0
                },
            };

            modelBuilder.Entity<Subject>().HasData(subjects);
            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<StudentSubject>().HasData(studentSubject);
        }

    }
}
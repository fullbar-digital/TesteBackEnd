using Microsoft.EntityFrameworkCore;
using StudentRegistration.WebApi.Models;

namespace StudentRegistration.WebApi.Context
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course { ID = 1, Option = "Arquitetura de Urbanismo" },
                new Course { ID = 2, Option = "Biologia" },
                new Course { ID = 3, Option = "Ciência da Computação" },
                new Course { ID = 4, Option = "Engenharia" },
                new Course { ID = 5, Option = "Fisioterapia" },
                new Course { ID = 6, Option = "Literatura" },
                new Course { ID = 7, Option = "Matemática" },
                new Course { ID = 8, Option = "Relações Internacionais" },
                new Course { ID = 9, Option = "Sistemas de Informação" }
                );
        }
    }
}

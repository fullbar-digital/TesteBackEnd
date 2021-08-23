using Fullbar.Entities.Models.Courses;
using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Models.Students;
using Microsoft.EntityFrameworkCore;


namespace Fullbar.Entities.Persistences
{
	public class FullbarDBContext : DbContext
	{
		public DbSet<Student> Student { get; set; }
		public DbSet<Course> Course { get; set; }
		public DbSet<Discipline> Discipline { get; set; }
		public DbSet<Grade> Grade { get; set; }

		public FullbarDBContext(DbContextOptions<FullbarDBContext> options)
		: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Course>().ToTable("Course");
			modelBuilder.Entity<Student>().ToTable("Student");
			modelBuilder.Entity<Grade>().ToTable("Grade");

			#region Seeder_Student
			modelBuilder.Entity<Student>().HasData(
				new Student()
				{
					Id = 1,
					Name = "Marco Bagdal 3",
					RA = "123456",
					Period = "Manha",
					Picture = "Marco.png",
					CourseId = 2

				}
			);

			modelBuilder.Entity<Student>().HasData(
				new Student()
				{
					Id = 2,
					Name = "Carlos Rodrigues",
					RA = "654321",
					Period = "Tarde",
					Picture = "carlos.jpg",
					CourseId = 1

				}
			);
			#endregion

			#region Seeder_Course
			modelBuilder.Entity<Course>().HasData(
				new Course()
				{
					CourseID = 1,
					Name = "Ciência da computação",
				}
			);

			modelBuilder.Entity<Course>().HasData(
				new Course()
				{
					CourseID = 2,
					Name = "Engenharia da computação",
				}
			);

			modelBuilder.Entity<Course>().HasData(
				new Course()
				{
					CourseID = 3,
					Name = "Engenharia de software",
				}
			);
			#endregion

			#region Seeder_Disciplines
			modelBuilder.Entity<Discipline>().HasData(
				new Discipline()
				{
					DisciplineID = 1,
					Name = "Calculo 1",
					CourseId = 1,
					MinimumGrade = 7
				}
			);

			modelBuilder.Entity<Discipline>().HasData(
				new Discipline()
				{
					DisciplineID = 2,
					Name = "Calculo 2",
					CourseId = 1,
					MinimumGrade = 7
				}
			);

			modelBuilder.Entity<Discipline>().HasData(
				new Discipline()
				{
					DisciplineID = 3,
					Name = "Calculo 3",
					CourseId = 3,
					MinimumGrade = 7
				}
			);
			#endregion

			#region Seeder_Grade
			modelBuilder.Entity<Grade>().HasData(
				new Grade()
				{
					GradeID = 1,
					StudentID = 1,
					DisciplineID = 2,
					StudantGrade = 7.2
				},
				new Grade()
				{
					GradeID = 2,
					StudentID = 2,
					DisciplineID = 2,
					StudantGrade = 4.23
				}
			);

			
			#endregion

		}
	}
}

using Fullbar.Entities.Models.Courses;
using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Models.Enrollments;
using Fullbar.Entities.Models.Students;
using Microsoft.EntityFrameworkCore;


namespace Fullbar.Entities.Persistences
{
	public class FullbarDBContext : DbContext
	{
		public DbSet<Student> Student { get; set; }
		public DbSet<Course> Course { get; set; }
		public DbSet<Discipline> Discipline { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }


		public FullbarDBContext(DbContextOptions<FullbarDBContext> options) : base(options)
		{
				
		}
	}
}

using Microsoft.EntityFrameworkCore;
using TesteBackEnd.Domain.Entities;

namespace TesteBackEnd.Infrastructure.Data.Context
{
    public class TesteBackEndDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<DisciplineEntity> Disciplines { get; set; }
        public DbSet<ScoreEntity> Scores { get; set; }
        public TesteBackEndDbContext(DbContextOptions<TesteBackEndDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var property in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetProperties())
				.Where(p => p.ClrType == typeof(string)))
			{
				property.SetColumnType("varchar(100)");
			}
			foreach (var relations in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
			{
				relations.DeleteBehavior = DeleteBehavior.ClientSetNull;
			}
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TesteBackEndDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
        }

    }
}
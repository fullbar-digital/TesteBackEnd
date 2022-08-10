using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Infrastructure.Data.Mappings;

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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentEntity>(new StudentMapping().Configure);
            modelBuilder.Entity<CourseEntity>(new CourseMapping().Configure);
            modelBuilder.Entity<DisciplineEntity>(new DisciplineMapping().Configure);
            modelBuilder.Entity<ScoreEntity>(new ScoreMapping().Configure);
        }

    }

    public class CdsIIContextFactory : IDesignTimeDbContextFactory<TesteBackEndDbContext>
    {
        public TesteBackEndDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TesteBackEndDbContext>();
            optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa; Password=1234&Abcd; Initial Catalog=TesteBackEnd;Data Source=localhost;");

            return new TesteBackEndDbContext(optionsBuilder.Options);
        }
    }
}

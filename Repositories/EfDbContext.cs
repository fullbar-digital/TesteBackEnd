using Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System.Reflection;


namespace Repositories
{
    public class EfDbContext : DbContext
    {
        //Core
        public DbSet<Course> Course { get; set; }
        public DbSet<SchoolReport> SchoolReport { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options)
        {
        }

        public EfDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Aplica todas as configurações (IEntityTypeConfiguration)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}


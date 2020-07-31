using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Domain;
using ApplicationCore.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Infrastructure.Data
{
    public class TesteBackEndContext : DbContext
    {
        public TesteBackEndContext(DbContextOptions<TesteBackEndContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new CourseMap());

            var now = DateTime.Now;

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course {Id = 1, Name = "Administração", Active = true, Created = now, Updated = now},
                    new Course {Id = 2, Name = "Ciências Contábeis", Active = true, Created = now, Updated = now},
                    new Course {Id = 3, Name = "Ciências Econômicas", Active = true, Created = now, Updated = now},
                    new Course {Id = 4, Name = "Comércio Exterior", Active = true, Created = now, Updated = now},
                    new Course {Id = 5, Name = "Design de Moda", Active = true, Created = now, Updated = now},
                    new Course {Id = 6, Name = "Gastronomia", Active = true, Created = now, Updated = now},
                    new Course {Id = 7, Name = "Gestão Comercial", Active = true, Created = now, Updated = now}
                );

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

            changedEntities.ForEach(e =>
            {
                var dateTime = DateTime.UtcNow;

                if (e.State == EntityState.Added)
                {
                    var created = e.Entity.GetType().GetProperty("Created");

                    if (created != null) created.SetValue(e.Entity, dateTime);
                }

                var updated = e.Entity.GetType().GetProperty("Updated");

                if (updated != null) updated.SetValue(e.Entity, dateTime);
            });

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

            changedEntities.ForEach(e =>
            {
                var dateTime = DateTime.UtcNow;

                if (e.State == EntityState.Added)
                {
                    var created = e.Entity.GetType().GetProperty("Created");

                    if (created != null) created.SetValue(e.Entity, dateTime);
                }

                var updated = e.Entity.GetType().GetProperty("Updated");

                if (updated != null) updated.SetValue(e.Entity, dateTime);
            });

            return base.SaveChanges();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.Data.Test
{
    public class DbContextTest : IDisposable
    {
        private string dbName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbContextTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<TesteBackEndDbContext>(
                o => o.UseSqlServer($"Persist Security Info=False;User ID=sa; Password=L30&t4t4; Initial Catalog={dbName};Data Source=localhost;"),
                ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();

            using (var context = ServiceProvider.GetService<TesteBackEndDbContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<TesteBackEndDbContext>())
            {
                context.Database.EnsureDeleted();
            }
        }

    }
}

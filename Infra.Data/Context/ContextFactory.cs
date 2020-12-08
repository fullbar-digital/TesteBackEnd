using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<BaseContext>
    {
        public BaseContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=.;Database=FullbarDigital;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new BaseContext(optionsBuilder.Options);
        }
    }
}
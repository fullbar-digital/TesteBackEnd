
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Infrastructure.CrossCutting.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
{
    public class DbContextConfiguration : IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<TesteBackEndDbContext>();
            serviceCollection.AddDbContext<TesteBackEndDbContext>(
               options => options.UseSqlServer(Environment.GetEnvironmentVariable("SqlServer")));

            return serviceCollection;
        }

    }
}


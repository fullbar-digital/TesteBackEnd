
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection
{
    public class DbContextConfiguration 
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


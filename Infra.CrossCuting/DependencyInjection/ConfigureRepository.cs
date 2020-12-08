using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Infra.Data.Context;
using Infra.Data.Repository;
using Infra.Data.Repository.Aluno;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCuting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IAlunoRepository, AlunoRepository>();

            serviceCollection.AddDbContext<BaseContext>(
                options => options.UseSqlServer("Server=.;Database=FullbarDigital;Trusted_Connection=True;MultipleActiveResultSets=true")
            );
        }
    }
}
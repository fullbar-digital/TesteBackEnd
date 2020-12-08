using Domain.Interfaces.Service.Aluno.Aluno;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Infra.CrossCuting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAlunoService, AlunoService>();
        }
    }
}
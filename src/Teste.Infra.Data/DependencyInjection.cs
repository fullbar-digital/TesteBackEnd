using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste.Domain.Alunos.Repositories;
using Teste.Domain.Common.Repositories;
using Teste.Domain.Cursos.Repositories;
using Teste.Domain.Disciplinas.Repositories;
using Teste.Infra.Data.Contexts;
using Teste.Infra.Data.Repositories;
using Teste.Infra.Data.Repositories.Common;

namespace Teste.Infra.Data
{
    public static class DependencyInjection
    {
        public static void ConfigureDataBase(this IServiceCollection service, IConfiguration configuration)
        {
            _ = service.AddDbContext<TesteContexto>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }

        public static void ConfigureRepositoriesDependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            service.AddScoped<ICursoRepository, CursoRepository>();
            service.AddScoped<IAlunoRepository, AlunoRepository>();
            service.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}

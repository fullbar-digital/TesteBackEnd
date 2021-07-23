using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Notificacoes;
using AppAlunos.Business.Services;
using AppAlunos.Data.Context;
using AppAlunos.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace AppAlunos.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            //Repository
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<ICursoDisciplinaRepository, CursoDisciplinaRepository>();
            services.AddScoped<IAlunoDisciplinaRepository, AlunoDisciplinaRepository>();

            //Services
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<INotificador, Notificador>();

            services.AddMvc()
                .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;

                });


            return services;
        }
    }
}

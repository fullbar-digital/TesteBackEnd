using Fullbar.Teste.Application.Interfaces;
using Fullbar.Teste.Application.Notificacoes;
using Fullbar.Teste.Application.Services;
using Fullbar.Teste.Infra.Context;
using Fullbar.Teste.Infra.Interfaces;
using Fullbar.Teste.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fullbar.Teste.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
           
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Teste.Application.Configuration;
using Teste.Application.Disciplinas.Cadastro;
using Teste.Application.MappingProfiles;

namespace Teste.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureMediator(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(typeof(CadastrarDisciplinaCommand).Assembly);
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CadastrarDisciplinaCommand>());
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationMappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}

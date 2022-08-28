using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TesteBackEnd.Infrastructure.CrossCutting.Interfaces;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
{
    public class SwaggerConfigurations : IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TesteBackEnd",
                    Description = "Uma aplicação web para cadastrar e gerenciar alunos",
                    Contact = new OpenApiContact
                    {
                        Name = "Valdir Leanderson Cirqueira de Oliveira",
                        Email = "valdirleanderson@yahoo.com.br"
                    }
                });
            });

            return serviceCollection;
        }
    }
}

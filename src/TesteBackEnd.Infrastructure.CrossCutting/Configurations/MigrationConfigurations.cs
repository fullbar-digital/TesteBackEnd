using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Infrastructure.CrossCutting.HostedServices;
using TesteBackEnd.Infrastructure.CrossCutting.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
{
    public class MigrationConfigurations : IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection _serviceCollection)
        {
            if (Environment.GetEnvironmentVariable("MIGRATE").ToLower().Equals("true".ToLower()))
            {
                _serviceCollection.AddHostedService<MigrationHostedService>();
            }

            return _serviceCollection;
        }

    }
}

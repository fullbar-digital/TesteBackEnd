using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Redis;
using TesteBackEnd.Infrastructure.CrossCutting.Interfaces;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
{
    public class RedisConfiguration : IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRedisClientsManager>(c =>
               new RedisManagerPool(Environment.GetEnvironmentVariable("REDIS_CONNECTION")));

            return serviceCollection;
        }

    }
}

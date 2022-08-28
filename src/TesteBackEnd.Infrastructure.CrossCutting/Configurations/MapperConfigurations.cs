using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Infrastructure.CrossCutting.Interfaces;
using TesteBackEnd.Infrastructure.CrossCutting.Mappings;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
{
    public class MapperConfigurations : IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
           {
               cfg.AddProfile(new DtoToModelProfile());
               cfg.AddProfile(new EntityToDtoProfile());
               cfg.AddProfile(new ModelToEntityProfile());
           });

            IMapper mapper = config.CreateMapper();

            serviceCollection.AddSingleton(mapper);

            return serviceCollection;
        }
    }
}

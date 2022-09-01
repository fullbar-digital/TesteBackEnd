using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TesteBackEnd.Infrastructure.CrossCutting.Interfaces
{
    public interface IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection);

    }
}

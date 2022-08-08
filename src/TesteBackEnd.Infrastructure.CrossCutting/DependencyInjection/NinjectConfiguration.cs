using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection
{
    public class NinjectConfiguration
    {
        private IKernel _kernel;
        
        public NinjectConfiguration()
        {
            
        }

        public NinjectConfiguration ConfigureRepositoryDependencies()
        {
            _kernel = new RepositoryConfiguration().Configure();
            return this;
        }

        public NinjectConfiguration ConfigureServiceDependencies()
        {
            _kernel = new ServiceConfiguration().Configure();
            return this;
        }

    }
}
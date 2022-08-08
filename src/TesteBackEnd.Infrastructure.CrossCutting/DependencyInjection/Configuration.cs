using Microsoft.Extensions.DependencyInjection;

namespace TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection
{
    public class Configuration
    {
        private IServiceCollection _serviceCollection;
        
        public Configuration(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public Configuration ConfigureDbContext()
        {
            _serviceCollection = new DbContextConfiguration().Configure(_serviceCollection);
            return this;
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
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

        public Configuration ConfigureServices()
        {
            _serviceCollection = new ServicesIoCConfigurations().Configure(_serviceCollection);
            return this;
        }

        public Configuration ConfigureRepositories()
        {
            _serviceCollection = new RepositoriesIoCConfigurations().Configure(_serviceCollection);
            return this;
        }

        public Configuration ConfigureMigrations()
        {
            _serviceCollection = new MigrationConfigurations().Configure(_serviceCollection);
            return this;
        }

        public Configuration ConfigureSwagger()
        {
            _serviceCollection = new SwaggerConfigurations().Configure(_serviceCollection);
            return this;
        }

        public Configuration ConfigureRedis()
        {
            _serviceCollection = new RedisConfiguration().Configure(_serviceCollection);
            return this;
        }

        public Configuration ConfigureMappings()
        {
            _serviceCollection = new MapperConfigurations().Configure(_serviceCollection);
            return this;
        }
    }
}

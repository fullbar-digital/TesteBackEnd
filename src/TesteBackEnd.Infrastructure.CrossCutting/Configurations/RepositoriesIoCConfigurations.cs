using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Caching.Interfaces;
using TesteBackEnd.Infrastructure.Caching.Repository;
using TesteBackEnd.Infrastructure.CrossCutting.Interfaces;
using TesteBackEnd.Infrastructure.Data.Repository;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
{
    public class RepositoriesIoCConfigurations : IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IQuery<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(ICommand<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
            serviceCollection.AddScoped<IDisciplineRepository, DisciplineRepository>();
            serviceCollection.AddScoped<IScoreRepository, ScoreRepository>();
            serviceCollection.AddScoped<ILogRepository, LogRepository>();
            serviceCollection.AddScoped<ICacheRepository, CacheRepository>();

            return serviceCollection;
        }

    }
}

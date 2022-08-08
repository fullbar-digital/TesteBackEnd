using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;
using TesteBackEnd.Infrastructure.Data.Repository;

namespace TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection
{
    public class RepositoriesIoCConfigurations
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {


            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
            serviceCollection.AddScoped<IDisciplineRepository, DisciplineRepository>();
            serviceCollection.AddScoped<IScoreRepository, ScoreRepository>();




            return serviceCollection;
        }

    }
}

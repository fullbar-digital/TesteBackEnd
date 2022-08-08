using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Notifications;
using TesteBackEnd.Service.Services;

namespace TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection
{
    public class ServicesIoCConfigurations
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<INotifier, Notifier>();
            serviceCollection.AddScoped<IStudentService, StudentService>();
            serviceCollection.AddScoped<ICourseService, CourseService>();
            serviceCollection.AddScoped<IDisciplineService, DisciplineService>();
            serviceCollection.AddScoped<IScoreService, ScoreService>();

            return serviceCollection;
        }
    }
}

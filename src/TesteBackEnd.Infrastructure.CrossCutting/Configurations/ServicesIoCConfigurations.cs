using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Notifications;
using TesteBackEnd.Infrastructure.CrossCutting.Interfaces;
using TesteBackEnd.Service.Services;

namespace TesteBackEnd.Infrastructure.CrossCutting.Configurations
{
    public class ServicesIoCConfigurations : IServiceConfiguration
    {
        public IServiceCollection Configure(IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<INotifier, Notifier>();
            serviceCollection.AddScoped<IStudentService, StudentService>();
            serviceCollection.AddScoped<ICourseService, CourseService>();
            serviceCollection.AddScoped<IDisciplineService, DisciplineService>();
            serviceCollection.AddScoped<IScoreService, ScoreService>();
            serviceCollection.AddScoped<ILogService, LogService>();

            return serviceCollection;
        }
    }
}

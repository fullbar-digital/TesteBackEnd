using Microsoft.Extensions.DependencyInjection;
using Ninject;
using Ninject.Modules;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Notifications;
using TesteBackEnd.Service.Services;

namespace TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection
{
    public class ServiceConfiguration 
    {
        public IKernel Configure()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IStudentService>().To<StudentService>();
            kernel.Bind<INotifier>().To<Notifier>();  
            return kernel;
        }
    }
}
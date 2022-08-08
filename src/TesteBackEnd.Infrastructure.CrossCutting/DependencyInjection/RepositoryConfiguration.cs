using Microsoft.Extensions.DependencyInjection;
using Ninject;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Infrastructure.Data.Context;
using TesteBackEnd.Infrastructure.Data.Repository;

namespace TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection
{
    public class RepositoryConfiguration
    {
        public IKernel Configure()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IStudentRepository>().To<StudentRepository>();  
            return kernel;
        }

    }
}
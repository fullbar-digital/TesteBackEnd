using ApplicationCore.Domain.Repositories;
using ApplicationCore.Infrastructure.Data;
using ApplicationCore.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore.Infrastructure
{
    public static class SimpleInjectorContainer
    {
        public static IServiceCollection ConfigureDependecies(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<TesteBackEndContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    builder => builder.UseRowNumberForPaging()));

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            return services;
        }
    }
}
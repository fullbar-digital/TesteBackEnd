using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using course.manager.webapi.Interfaces;
using grade.manager.webapi.Interfaces;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Services;
using Newtonsoft.Json;

namespace student.manager.webapi.Infraestructure
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();
            services.AddLogging();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Manager Web Api", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.For<IStudentService>().Use<StudentService>();
            services.For<ICourseService>().Use<CourseService>();
            services.For<ISubjectService>().Use<SubjectService>();
            services.For<IGradeService>().Use<GradeService>();
            services.For<ICourseSubjectService>().Use<CourseSubjectService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Manager Web Api");
            });

            app.UseMvc();
        }
    }
}

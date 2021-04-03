using System;
using App.Domain.Handlers;
using App.Domain.Repositories;
using App.Domain.Infra.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using App.Domain.Infra.Respositories;
using App.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.Domain.Api", Version = "v1" });
            });

            //Services - Student
            services.AddScoped<CreateStudentHandler, CreateStudentHandler>();
            services.AddScoped<GetAllStudentsHandler, GetAllStudentsHandler>();
            services.AddScoped<DeleteStudentsHandler, DeleteStudentsHandler>();
            services.AddScoped<UpdateStudentHandler, UpdateStudentHandler>();
            services.AddScoped<GetStudentsByFilterHandler, GetStudentsByFilterHandler>();
            //Services - Courses
            services.AddScoped<CreateCourseHandler, CreateCourseHandler>();
            //Services - Subject
            services.AddScoped<CreateSubjectHandler, CreateSubjectHandler>();
            //Contracts
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();



            //Database
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.Domain.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

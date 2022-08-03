using Manager.API.Model;
using AutoMapper;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interfaces;
using Service.Services;
using Service.Dto;
using Microsoft.OpenApi.Models;

namespace Manager.API
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5001/v1/disciplina/create",
                                            "http://localhost:3000")
                                .WithMethods("PUT", "DELETE", "GET");
                    });
            });

            services.AddControllers();

            services.AddSingleton(d => Configuration);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:Manager"]), ServiceLifetime.Transient);

            services.AddScoped<ISubjectSer, SubjectSer>();
            services.AddScoped<ISubjectRep, SubjectRep>();

            services.AddScoped<ICourseSer, CourseSer>();
            services.AddScoped<ICourseRep, CourseRep>();

            services.AddScoped<ICourseSubjectRep, CourseSubjectRep>();

            services.AddScoped<IStudentRep, StudentRep>();
            services.AddScoped<IStudentSer, StudentSer>();

            services.AddScoped<IStudentSubjectRep, StudentSubjectRep>();

            

            //AMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Subject, SubjectDto>().ReverseMap();
                cfg.CreateMap<SubjectDto, SubjectVm>().ReverseMap();

                cfg.CreateMap<Course, CourseDto>().ReverseMap();
                cfg.CreateMap<CourseDto, CreateCourse>().ReverseMap();

                cfg.CreateMap<CourseSubject, CourseSubjectDto>().ReverseMap();

                cfg.CreateMap<Student, StudentDto>().ReverseMap();
                cfg.CreateMap<CreateStudent, StudentDto>().ReverseMap();

                cfg.CreateMap<StudentSubject, StudentSubjectDto>().ReverseMap();
                cfg.CreateMap<StudentSubjectVm, StudentSubjectDto>().ReverseMap();

            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            

            // Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Manager.API",
                    Version = "v1",
                    Description = "Cadastro e Consulta de Alunos.",
                    Contact = new OpenApiContact
                    {
                        Name = "Anderson Luis",
                        Email = "andersonluis1486@gmail.com"
                    },
                });

            });

            

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteCRUD v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

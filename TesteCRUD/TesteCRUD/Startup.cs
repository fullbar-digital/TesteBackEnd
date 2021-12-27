using API.ViewModel.Aluno;
using API.ViewModel.Disciplina;
using AutoMapper;
using Dominio.Entidades;
using Infra.Contexto;
using Infra.Interfaces;
using Infra.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Servico.DTO;
using Servico.Interfaces;
using Servico.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCRUD.ViewModel;

namespace TesteCRUD
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

            #region DI

            services.AddSingleton(d => Configuration);
            services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration["ConnectionStrings:Homolog"]), ServiceLifetime.Transient);

            services.AddScoped<IDisciplinaServico, DisciplinaServico>();
            services.AddScoped<IDisciplinaRepositorio, DisciplinaRepositorio>();

            services.AddScoped<ICursoServico, CursoServico>();
            services.AddScoped<ICursoRepositorio, CursoRepositorio>();

            services.AddScoped<ICursoDisciplinaRepositorio, CursoDisciplinaRepositorio>();

            services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
            services.AddScoped<IAlunoServico, AlunoServico>();

            services.AddScoped<IAlunoDisciplinaRepositorio, AlunoDisciplinaRepositorio>();

            #endregion

            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Disciplina, DisciplinaDTO>().ReverseMap();
                cfg.CreateMap<DisciplinaDTO, DisciplinaVm>().ReverseMap();

                cfg.CreateMap<Curso, CursoDTO>().ReverseMap();
                cfg.CreateMap<CursoDTO, CriarCursoVM>().ReverseMap();

                cfg.CreateMap<CursoDisciplina, CursoDisciplinaDTO>().ReverseMap();

                cfg.CreateMap<Aluno, AlunoDTO>().ReverseMap();
                cfg.CreateMap<CriarAlunoVM, AlunoDTO>().ReverseMap();

                cfg.CreateMap<AlunoDisciplina, AlunoDisciplinaDTO>().ReverseMap();
                cfg.CreateMap<AlunoDisciplinaVM, AlunoDisciplinaDTO>().ReverseMap();

            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    Description = "API constru�da por Matheus Veiga.",
                    Contact = new OpenApiContact
                    {
                        Name = "Matheus Veiga",
                        Email = "matheus.jveiga@gmail.com"
                    },
                });

            });

            #endregion

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

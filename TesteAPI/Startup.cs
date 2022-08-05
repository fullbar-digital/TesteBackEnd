using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TesteAPI
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

            //string conexao = "Server=localhost;Database=api;Uid=root;password=P68dd2mw0@";
            //string conexao = "Server=sql10.freesqldatabase.com;Database=sql10510543;Uid=sql10510543;password=ZPRDIJfbNL";

            services.AddSingleton(Configuration);
            //services.AddMvc();           
            services = AddMapper(services);

            //Ninject
            services.AddScoped<BLL.Interfaces.IAlunoBLL, BLL.AlunoBLL>();
            services.AddScoped<BLL.Interfaces.ICursoBLL, BLL.CursoBLL>();
            services.AddScoped<BLL.Interfaces.IDisciplinaBLL, BLL.DisciplinaBLL>();
            services.AddScoped<BLL.Interfaces.IAlunoNotaBLL, BLL.AlunoNotaBLL>();
            services.AddScoped<BLL.Interfaces.IUsuarioBLL, BLL.UsuarioBLL>();
            services.AddScoped<DAL.Repositories.Interfaces.IUnitOfWork, DAL.Repositories.UnitofWork>();
            //services.AddScoped<DAL.Repositories.Interfaces.IRepository,DAL.Repositories.Repository>();   
            
            services.AddDbContext<DAL.Contexto>(opt => opt.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\TesteApi;Initial Catalog=teste;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True"));
            

            services.AddCors();

            //Token
            var key = Encoding.ASCII.GetBytes(Services.Token.Settings.Secret());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            

            services.AddControllers()
                .AddJsonOptions(x =>
                {                  
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
                       

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesteAPI", Version = "v1" });
                
            });       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteAPI v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public IServiceCollection AddMapper(IServiceCollection service)
        {
         
            service.AddSingleton(provider => new MapperConfiguration((mapper) =>
            {
                mapper.AddProfile<Services.AutoMapper.AlunoAlunoVOMapping>();
                mapper.AddProfile<Services.AutoMapper.CursoCursoVOMapping>();
                mapper.AddProfile<Services.AutoMapper.DisciplinaDisciplinaVOMapping>();
                mapper.AddProfile<Services.AutoMapper.AlunoNotaAlunoNotaVOMapping>();
                mapper.AddProfile<Services.AutoMapper.NotaCadastroVOAlunoNotaMapping>();
                //mapper.AddProfile<Services.AutoMapper.AlunoAlunoDetailsVOMapping>();
                mapper.AddProfile(new Services.AutoMapper.AlunoAlunoDetailsVOMapping(provider.CreateScope().ServiceProvider.GetService<DAL.Repositories.Interfaces.IUnitOfWork>()));

            }).CreateMapper());

            

            return service;
        }
    }
}

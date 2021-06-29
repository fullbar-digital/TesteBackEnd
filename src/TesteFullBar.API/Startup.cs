using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO.Compression;
using TesteFullBar.API.Filters;
using TesteFullBar.API.Services;
using TesteFullBar.API.Services.Interfaces;
using TesteFullBar.API.Settings;
using TesteFullBar.Domain.Interfaces.Notifications;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Interfaces.UoW;
using TesteFullBar.Domain.Models.Notifications;
using TesteFullBar.Infra.Context;
using TesteFullBar.Infra.Repository;
using TesteFullBar.Infra.UoW;

namespace TesteFullBar.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc(options =>
            {
                options.Filters.Add<DomainNotificationFilter>();
                options.EnableEndpointRouting = false;
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(x =>
            {
                x.Providers.Add<GzipCompressionProvider>();
            });

            this.RegisterHttpClient(services);

            if (!WebHostEnvironment.IsProduction())
            {
                services.AddOpenApiDocument(document =>
                {
                    document.UseControllerSummaryAsTagDescription = true;
                    document.DocumentName = "v1";
                    document.Version = "v1";
                    document.Title = "TesteFullBar API";
                    document.Description = "TesteFullBar API";
                });
            }

            services.AddAutoMapper(typeof(Startup));
            services.AddHttpContextAccessor();
            services.AddApplicationInsightsTelemetry();

            this.RegisterServices(services);
            this.RegisterDatabaseServices(services);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ApplicationInsightsSettings> options)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseResponseCompression();

            if (!env.IsProduction())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private void RegisterHttpClient(IServiceCollection services)
        {

        }

        protected virtual void RegisterServices(IServiceCollection services)
        {
            services.Configure<ApplicationInsightsSettings>(Configuration.GetSection("ApplicationInsights"));

            #region Service
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();

            #endregion

            #region Domain

            services.AddScoped<IDomainNotification, DomainNotification>();

            #endregion

            #region Infra


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAlunoDisciplinaRepository, AlunoDisciplinaRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();

            #endregion
        }

        protected virtual void RegisterDatabaseServices(IServiceCollection services)
        {
            services.AddDbContext<EntityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("db")));
            services.AddTransient<DbConnection>(conn => new SqlConnection(Configuration.GetConnectionString("db")));
            services.AddScoped<DapperContext>();

        }
    }
}

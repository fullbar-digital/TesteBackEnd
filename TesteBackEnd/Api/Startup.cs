using System.Linq;
using System.Net;
using Api.Support;
using ApplicationCore.Domain.Shared;
using ApplicationCore.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    /// <summary>
    ///     Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     Configuração
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///     Configuração do serviço
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.ConfigureMvc();

            services.AddHttpContextAccessor();
            services.ConfigureSwagger();
            services.ConfigureDependecies(Configuration);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();

                    var result = new
                    {
                        Code = "00009",
                        Message = "Validation Errors",
                        Errors = errors
                    };

                    return new BadRequestObjectResult(result);
                };
            });
        }

        /// <summary>
        ///     Configuração
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    var feat = context.Features.Get<IExceptionHandlerFeature>();
                    var types = new[] { typeof(DomainException), typeof(ValidationException) };

                    if (types.Any(s => s == feat.Error.GetType()))
                        context.Response.StatusCode = (short)HttpStatusCode.BadRequest;
                    else
                        context.Response.StatusCode = (short)HttpStatusCode.InternalServerError;

                    await context.Response.WriteAsync(feat.Error.Message);
                });
            });

            app.UseCors("CorsPolicy");
            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint("/swagger/v1/swagger.json", "API Teste - FullBar");
                sw.RoutePrefix = "docs";
            });
        }
    }
}

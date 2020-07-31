using System;
using System.IO;
using FluentValidation.AspNetCore;
using Hisoka.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Api.Support
{
    /// <summary>
    ///     Extensões de serviços
    /// </summary>
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials()
                )
            );

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddHisoka(options =>
                {
                    options.PageNumberQueryAlias = "pagina";
                    options.DefaultPageSize = 15;
                })
                .AddFluentValidation(options => { options.RegisterValidatorsFromAssemblyContaining<Startup>(); });

            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Api de Teste - FullBar",
                    Version = "v1"
                });

                options.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Api.xml"));
                options.DescribeAllEnumsAsStrings();
                options.DescribeAllParametersInCamelCase();
            });

            return services;
        }
    }
}

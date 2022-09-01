using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;
using Serilog.Sinks.MSSqlServer;
using TesteBackEnd.Application.Exceptions;
using TesteBackEnd.Infrastructure.CrossCutting.Configurations;
using TesteBackEnd.Infrastructure.CrossCutting.Mappings;
using TesteBackEnd.Infrastructure.Data.Context;

try
{

    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithCorrelationId()
            .Enrich.WithProperty("ApplicationName", $"TesteBackEnd - {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}")
            .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
            .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
            .WriteTo.Async(x => x.MSSqlServer(Environment.GetEnvironmentVariable("SqlServer"), sinkOptions: new MSSqlServerSinkOptions()
            {
                AutoCreateSqlTable = true,
                TableName = "Logs"
            })
            .WriteTo.Console())
    .CreateLogger();

    builder.Host.UseSerilog(Log.Logger);


    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    new Configuration(builder.Services)
         .ConfigureDbContext()
         .ConfigureServices()
         .ConfigureRepositories()
         .ConfigureMigrations()
         .ConfigureRedis()
         .ConfigureMappings()
         .ConfigureSwagger();




    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteBackEnd.Api v1"));
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
    app.MapControllers();

    app.ConfigureBuildInExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

    app.Run();
}
finally
{
    Log.CloseAndFlush();
}

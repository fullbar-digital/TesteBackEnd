using AutoMapper;
using Microsoft.OpenApi.Models;
using TesteBackEnd.Infrastructure.CrossCutting.DependencyInjection;
using TesteBackEnd.Infrastructure.CrossCutting.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "TesteBackEnd",
        Description = "Uma aplicação web para cadastrar e gerenciar alunos",
        Contact = new OpenApiContact
        {
            Name = "Valdir Leanderson Cirqueira de Oliveira",
            Email = "valdirleanderson@yahoo.com.br"
        }
    });
});
new Configuration(builder.Services)
    .ConfigureDbContext()
    .ConfigureServices()
    .ConfigureRepositories();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new DtoToModelProfile());
    cfg.AddProfile(new EntityToDtoProfile());
    cfg.AddProfile(new ModelToEntityProfile());
});


IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);


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



app.Run();

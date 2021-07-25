using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using student.manager.webapi.Infraestructure;

namespace student.manager.webapi
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //Carrega a instância do banco de dados
                var myDbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                //Executa os migrations ainda não executados
                myDbContext.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseLamar()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    webBuilder.UseUrls(@"http://localhost:5000");
                });
        }
    }
}

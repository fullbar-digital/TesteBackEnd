using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using student.manager.webapi.Infraestructure;

namespace student.manager.webapi
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(@"http://localhost:5000");
    }
}

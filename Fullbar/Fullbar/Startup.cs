using Fullbar.Entities.Persistences;
using Fullbar.Repositories.Courses;
using Fullbar.Repositories.Disciplines;
using Fullbar.Repositories.Interfaces;
using Fullbar.Repositories.Students;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Fullbar.Repositories.Grades;

namespace Fullbar
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
			services.AddControllers()
				.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

			services.AddDbContext<FullbarDBContext>(
				options => options.UseSqlServer(Configuration.GetConnectionString("DevelopmentConnection"),
				 b => b.MigrationsAssembly("Fullbar")
			));

			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<ICourseRepository, CourseRepository>();
			services.AddScoped<IDisciplineRepository, DisciplineRepository>();
			services.AddScoped<IGradeRepository, GradeRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

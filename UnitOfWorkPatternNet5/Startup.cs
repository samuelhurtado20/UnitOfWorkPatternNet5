using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UnitOfWorkPatternNet5.Data;
using UnitOfWorkPatternNet5.Interfaces;
using UnitOfWorkPatternNet5.Repositories;
using UnitOfWorkPatternNet5.Services;

namespace UnitOfWorkPatternNet5
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

			services.AddControllers();

			services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();

			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<ICustomerService, CustomerService>();

			services.AddDbContext<UnitOfWorkPatternNet5Context>(opt => opt.UseInMemoryDatabase("MockDB"));

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "RepositoryPatternNet5Api", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RepositoryPatternNet5Api v1"));
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

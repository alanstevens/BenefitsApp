using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Paylocity.Benefits.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddFeatureFolders();
            services.AddMediatR(GetType().Assembly);

            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase("Employees")
                .Options;
            var context = new EmployeeDbContext(options);

            services.AddSingleton(context);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(GetType().Assembly));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Mapper.AssertConfigurationIsValid();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
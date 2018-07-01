using System;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Paylocity.API.Shared;

namespace Paylocity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddFeatureFolders();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMediatR(GetType().Assembly);

            var dbContextOptions = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase("Employees")
                .Options;
            var context = new ApiDbContext(dbContextOptions);

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

            app.UseCors("AllowAll");

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}

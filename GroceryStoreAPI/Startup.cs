﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GroceryStoreAPI
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
            services.AddMvc(options =>
           options.EnableEndpointRouting = false)
           .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

          //  services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "Customers",
                    areaName: "Customers",
                    template: "Customers/{controller=Customers}/{action=Index}/{id?}"
                    );
                routes.MapAreaRoute(
                    name: "Order",
                    areaName: "Order",
                    template: "Services/{controller=Order}/{action=Index}/{id?}"
                    );
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Customers}/{action=GetAllCustmerList}/{id?}");
            });
        }
    }
}

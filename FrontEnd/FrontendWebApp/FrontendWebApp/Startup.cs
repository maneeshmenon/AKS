using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontendWebApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FrontendWebApp
{
    public class Startup
    {
        public static string BackendServiceURL = "";
        public static string BackendRequestedService = "";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string ServiceURL
        {
            get
            {
                return this.Configuration["AppConfiguration:ServiceURL"];
            }
        }

        public string RequestedServiceHardCoded
        {
            get
            {
                return this.Configuration["AppConfiguration:RequestedServiceHardCoded"];
            }
        }

        public string RequestedServicePrivateNetwork
        {
            get
            {
                return this.Configuration["AppConfiguration:RequestedServicePrivateNetwork"];
            }
        }

        public string RequestedServicePublicInternet
        {
            get
            {
                return this.Configuration["AppConfiguration:RequestedServicePublicInternet"];
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllersWithViews();
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
            services.Configure<AppConfiguration>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            BackendServiceURL = ServiceURL;
            BackendRequestedService = RequestedServicePrivateNetwork;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

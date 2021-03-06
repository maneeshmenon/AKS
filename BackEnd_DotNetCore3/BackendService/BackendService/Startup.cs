using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using BackendService.Models;

namespace BackendService
{
    public class Startup
    {

        public static string BackendServiceURLPublicInternet = "";
        public static string BackendRequestedServicePublicInternet = "";

        public static string BackendServiceURLPrivateNetwork = "";
        public static string BackendRequestedServicePrivateNetwork = "";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string ServiceURLPublicInternet
        {
            get
            {
                return this.Configuration["AppConfiguration:ServiceURLPublicInternet"];
            }
        }

        public string RequestedServicePublicInternet
        {
            get
            {
                return this.Configuration["AppConfiguration:RequestedServicePublicInternet"];
            }
        }

        public string ServiceURLPrivateNetwork
        {
            get
            {
                return this.Configuration["AppConfiguration:ServiceURLPrivateNetwork"];
            }
        }

        public string RequestedServicePrivateNetwork
        {
            get
            {
                return this.Configuration["AppConfiguration:RequestedServicePrivateNetwork"];
            }
        }

        public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppConfiguration>(Configuration.GetSection("AppConfiguration"));
            services.Configure<AppConfiguration>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            BackendServiceURLPublicInternet = ServiceURLPublicInternet;
            BackendRequestedServicePublicInternet = RequestedServicePublicInternet;

            BackendServiceURLPrivateNetwork = ServiceURLPrivateNetwork;
            BackendRequestedServicePrivateNetwork = RequestedServicePrivateNetwork;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

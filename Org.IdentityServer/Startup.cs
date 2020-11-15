// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Org.IdentityServer.Helpers;
using Org.IdentityServer.Infrastructure;
using System;
using System.Linq;

namespace Org.IdentityServer
{
    public class Startup
    {       
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }


        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();

            SQLDbConfig sqlDbConfig = new SQLDbConfig();
            Configuration.Bind(nameof(SQLDbConfig), sqlDbConfig);            
            var builder = StartupConfig.ConfigureServices(services, sqlDbConfig);           

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  
            }
            InitializeDatabase(app);
            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                InitConfigDb.InitializeClients(context);
                InitConfigDb.InitializeIdentityResources(context);
                InitConfigDb.InitializeApiResources(context);
                context.SaveChanges();
            }
            
        }
    }
}

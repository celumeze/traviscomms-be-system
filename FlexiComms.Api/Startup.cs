using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexiComms.Data.Repository;
using FlexiComms.Data.Repository.Bindings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlexiComms.Api
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
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("FlexicommsOpenAPISpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Flexicomms API",
                    Version = "1"
                    //Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Charles Elumeze", Email = "charleelumeze@gmail.com" }
                });
            });
            CosmosDbConfig cosmosDbConfig = new CosmosDbConfig();
            SQLDbConfig sqlDbConfig = new SQLDbConfig();
            Configuration.Bind(nameof(CosmosDbConfig), cosmosDbConfig);
            Configuration.Bind(nameof(SQLDbConfig), sqlDbConfig);
            StartupDb.ConfigureServices(services, cosmosDbConfig, sqlDbConfig);        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(setupAction => 
            {
                setupAction.SwaggerEndpoint("/swagger/FlexicommsOpenAPISpecification/swagger.json", "Flexicomms API");
                setupAction.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

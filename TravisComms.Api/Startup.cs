using System.Linq;
using AutoMapper;
using TravisComms.Api.Profiles;
using TravisComms.Data.Repository;
using TravisComms.Data.Repository.Bindings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text;
using TravisComms.Api.Dto;
using TravisComms.Api.Middleware;
using TravisComms.Sender.Module;
using IdentityServer4.AccessTokenValidation;
using TravisComms.CsvProcessing.Interfaces;
using TravisComms.CsvProcessing.Processors;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TravisComms.Api.HostedServices;

namespace TravisComms.Api
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
           // services.AddResponseCaching();

            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options => 
                    {
                        options.InvalidModelStateResponseFactory = context =>
                        {
                            StringBuilder errorBuilder = new StringBuilder();
                            context.ModelState.ToList().ForEach(modelSate =>
                            {
                                foreach (var error in modelSate.Value.Errors)
                                {
                                    errorBuilder.AppendLine(error.ErrorMessage);
                                }
                            });
                            ResponseMessageDto responseMessage = new ResponseMessageDto 
                            { 
                                ErrorMessage = errorBuilder.ToString() 
                            };
                            return new UnprocessableEntityObjectResult(responseMessage);
                        };
                    });

            ///setting scope and authentication for IDP            
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = "https://localhost:5001";
                        options.ApiName = "traviscomms-api";
                        options.RequireHttpsMetadata = true;
                    });

            CosmosDbConfig cosmosDbConfig = new CosmosDbConfig();
            SQLDbConfig sqlDbConfig = new SQLDbConfig();
            Configuration.Bind(nameof(SQLDbConfig), sqlDbConfig);
            Configuration.Bind(nameof(CosmosDbConfig), cosmosDbConfig);
            StartupDb.ConfigureApiResourceStore(services, sqlDbConfig);
            StartupDb.ConfigureApiCosmosDb(cosmosDbConfig);
            services.TryAddSingleton<IContactsCsvParser, ContactsCsvParser>();
            services.TryAddScoped<IContactsResultProcessor, ContactsResultProcessor>();

            //Service Bus                        
            StartupMessenger.ConfigureServiceBus(services, Configuration);

            //Add Hosted/Background Services
            services.AddSingleton<ContactsCsvParsingChannel>();
            services.AddHostedService<ContactsCsvProcessingService>();
            

            //enable Cross Origin Site Requests
            services.AddCors(options =>
            {
                options.AddPolicy("AllRequests", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                    //.SetIsOriginAllowed(origin => origin == "http://localhost:8100");
                    //.AllowCredentials();
                });
            });

            //swagger documentation for Opern API specification document
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("TravisCommsOpenAPISpecification", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "TravisComms API",
                    Version = "1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Charles Elumeze", Email = "charleselumeze@gmail.com" }
                });
            });
                               
            
            //adds authorize filter to all endpoints
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddNewtonsoftJson();

            //automapper
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            //for file download
            services.Configure<FormOptions>(f =>
            {
                f.ValueLengthLimit = int.MaxValue;
                f.MultipartBodyLengthLimit = int.MaxValue;
                f.MemoryBufferThreshold = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/exceptionerror");
            }
            else
            {
                //add exception custom midlleware to the pipeline
                app.UseGlobalException();
            }
            
            app.UseHttpsRedirection();
            //app.UseResponseCaching();
            app.UseSwagger();

            app.UseSwaggerUI(setupAction => 
            {
                setupAction.SwaggerEndpoint("/swagger/TravisCommsOpenAPISpecification/swagger.json", "TravisComms API");
                setupAction.RoutePrefix = string.Empty;
            });

           
            
            app.UseRouting();
            app.UseCors("AllRequests");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

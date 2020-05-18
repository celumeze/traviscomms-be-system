using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TravisComms.Data.Repository;
using TravisComms.Data.Repository.IdentityModels;
using TravisComms.Messaging;

namespace TravisComms.Api.IntegrationTests
{
    public class CustomWebApiFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                //remove the api dbcontext registration
                var dbDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TravisCommsSqlDbContext>));
                var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IBusControl));

                if(dbDescriptor != null)
                {
                    services.Remove(dbDescriptor);
                }
                //if(serviceDescriptor != null)
                //{
                //    services.Remove(serviceDescriptor);
                //}

                //add the api dbcontext using in-memory db
                services.AddDbContextPool<TravisCommsSqlDbContext>(options =>
                {
                    options.UseInMemoryDatabase($"TravisCommsTestingDb{Guid.NewGuid()}");
                });

                //build the service provider
                var serviceProvider = services.BuildServiceProvider();

                //create a scope to obtain a reference to the database
                //dbcontext
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<TravisCommsSqlDbContext>();                    
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApiFactory<TStartup>>>();

                    //Ensure the databse is created
                    db.Database.EnsureCreated();

                    //seed db with test data
                    //InitializeDb(db);
                    
                    //configure services

                }
            });

            //base.ConfigureWebHost(builder);
        }

        private void InitializeDb(TravisCommsSqlDbContext context)
        {
            var mainRole = new MainRole
            {
                Id = "833583c3-1d58-4b95-baad-05b35acdd6a3",
                ConcurrencyStamp = "ef51e739-98e5-4455-9ae0-061ebfdda460",
                NormalizedName = "ADMIN",
                AccountHolderRoleId = Guid.Parse("CB0A792B-BF55-46B5-8795-10C43006BE92"),
                Name = "Admin",
                DateCreated = DateTime.ParseExact("17/04/2020 18:15:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("en-gb")),
                CreatedBy = "TravisComms\\System"

            };
            context.Roles.Add(mainRole);
            context.SaveChanges();
        }
    }
}

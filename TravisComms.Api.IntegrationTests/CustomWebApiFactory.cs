using MassTransit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
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
                //var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IBusControl));

                if (dbDescriptor != null)
                {
                    services.Remove(dbDescriptor);
                }               
                //add the api dbcontext using in-memory db
                services.AddDbContextPool<TravisCommsSqlDbContext>(options =>
                {
                    options.UseInMemoryDatabase($"TravisCommsTestingDb{Guid.NewGuid()}");
                });            
            });

        }
    }
}

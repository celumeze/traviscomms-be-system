using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TravisComms.Data.Repository;
using TravisComms.Data.Repository.IdentityModels;
using Xunit;

namespace TravisComms.Api.IntegrationTests
{
    public class IntegrationBase : IClassFixture<CustomWebApiFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationBase(CustomWebApiFactory<Startup> factory)
        {
            _factory = factory;
        }

        protected WebApplicationFactory<Startup> GetFactory(bool hasUser = false)
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<TravisCommsSqlDbContext>();
                //seed db with test data                               
                InitializeDb(db);
                if (hasUser)
                {
                    return _factory.WithWebHostBuilder(builder =>
                    {
                        builder.ConfigureServices(services =>
                        {
                            services.AddMvc(options =>
                            {
                                options.Filters.Add(new AllowAnonymousFilter());
                            });
                        });
                    });
                }
                return _factory;
            }
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

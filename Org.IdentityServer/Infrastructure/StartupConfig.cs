using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Org.IdentityServer.Models;
using Org.IdentityServer.Data;
using Org.IdentityServer.Extensions;
using Org.IdentityServer.Repository;
using System.Security.Cryptography.X509Certificates;

namespace Org.IdentityServer.Infrastructure
{
    public class StartupConfig
    {

        public static IIdentityServerBuilder ConfigureServices(IServiceCollection serviceCollection, SQLDbConfig sqlConnection)
        {

        // AspNet Identity Core
        serviceCollection.AddIdentity<MainUser, MainRole>()
                             .AddEntityFrameworkStores<TravisCommsIdentityDbContext>()
                             .AddUserStore<UserStore<MainUser, MainRole, TravisCommsIdentityDbContext>>();
            serviceCollection.AddIdentityCore<MainUser>(options => { });

            var migrationsAssembly = typeof(StartupConfig).GetTypeInfo().Assembly.GetName().Name;

            //Ef Core Migrations and Core Context Setup.
            serviceCollection.AddDbContextPool<TravisCommsIdentityDbContext>(opt =>
                      opt.UseSqlServer(
                          sqlConnection.ConnectionString,
                          sqlServerOptions => {
                              sqlServerOptions.MigrationsAssembly(migrationsAssembly);
                              sqlServerOptions.EnableRetryOnFailure();
                          }
             ));
            serviceCollection.AddRepositories();

            //IdentityServer4
            return serviceCollection.AddIdentityServer()
                             .AddAspNetIdentity<MainUser>()
                             .AddProfileService<IdentityProfileService>()
                             .AddConfigurationStore(storeOptions =>
                             {
                                 storeOptions.ConfigureDbContext = builder =>
                                 builder.UseSqlServer(sqlConnection.ConnectionString, options => 
                                 {
                                     options.MigrationsAssembly(migrationsAssembly);
                                     options.EnableRetryOnFailure();
                                 });
                             })
                             .AddOperationalStore(storeOptions =>
                             {
                                 storeOptions.ConfigureDbContext = builder =>
                                 builder.UseSqlServer(sqlConnection.ConnectionString, options =>
                                 {
                                     options.MigrationsAssembly(migrationsAssembly);
                                     options.EnableRetryOnFailure();
                                 }); 
                             });
        }

        public static void ConfigureApiResourceStore(IServiceCollection serviceCollection, SQLDbConfig sqlConnection)
        {
            serviceCollection.AddDbContextPool<TravisCommsIdentityDbContext>(options =>
                 options.UseSqlServer(sqlConnection.ConnectionString, sqlServerOptions => { sqlServerOptions.EnableRetryOnFailure(); }));
            serviceCollection.AddIdentityCore<MainUser>(options => { })
                              .AddDefaultTokenProviders();
            serviceCollection.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(3)); //sets the expiry period for tokens
            serviceCollection.AddScoped<IUserStore<MainUser>, UserStore<MainUser, MainRole, TravisCommsIdentityDbContext>>();
            serviceCollection.AddRepositories();
        }

    }
}

using TravisComms.Data.Repository.Bindings;
using TravisComms.Data.Repository.Extensions;
using TravisComms.Data.Repository.IdentityModels;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace TravisComms.Data.Repository
{
    public static class StartupDb
    {
        public static IIdentityServerBuilder ConfigureServices(IServiceCollection serviceCollection, CosmosDbConfig cosmosDbConfig, SQLDbConfig sqlConnection)
        {
         
            
            // AspNet Identity Core
            serviceCollection.AddIdentity<MainUser, MainRole>()
                             .AddEntityFrameworkStores<TravisCommsSqlDbContext>()
                             .AddUserStore<UserStore<MainUser, MainRole, TravisCommsSqlDbContext>>();
            serviceCollection.AddIdentityCore<MainUser>(options => {  });
            
            var migrationsAssembly = typeof(StartupDb).GetTypeInfo().Assembly.GetName().Name;

            //Ef Core Migrations and Core Context Setup.
            serviceCollection.AddDbContextPool<TravisCommsSqlDbContext>(opt =>
                      opt.UseSqlServer(
                          sqlConnection.ConnectionString,
                          sqlServerOptions => sqlServerOptions.MigrationsAssembly(migrationsAssembly)
             ));
            serviceCollection.AddRepositories();

            //IdentityServer4
            return serviceCollection.AddIdentityServer()
                             .AddAspNetIdentity<MainUser>()
                             .AddConfigurationStore(storeOptions =>
                             {
                                 storeOptions.ConfigureDbContext = builder =>
                                 builder.UseSqlServer(sqlConnection.ConnectionString, options => options.MigrationsAssembly(migrationsAssembly));
                             })
                             .AddOperationalStore(storeOptions =>
                             {
                                 storeOptions.ConfigureDbContext = builder =>
                                 builder.UseSqlServer(sqlConnection.ConnectionString, options => options.MigrationsAssembly(migrationsAssembly));
                             });                                                   
        }

        public static void ConfigureApiResourceStore(IServiceCollection serviceCollection, CosmosDbConfig cosmosDbConfig, SQLDbConfig sqlConnection)
        {
            serviceCollection.AddDbContext<TravisCommsSqlDbContext>(options =>
                 options.UseSqlServer(sqlConnection.ConnectionString));
            serviceCollection.AddIdentityCore<MainUser>(options => { })
                              .AddDefaultTokenProviders();
            serviceCollection.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(3)); //sets the expiry period for tokens
            serviceCollection.AddScoped<IUserStore<MainUser>, UserStore<MainUser, MainRole, TravisCommsSqlDbContext>>();
            serviceCollection.AddRepositories();
        }
    }
}

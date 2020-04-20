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
         
            //serviceCollection.AddDbContext<TravisCommsNoSqlDbContext>(opt => opt.UseCosmos(cosmosDbConfig.ServiceEndpoint, cosmosDbConfig.AuthKey, cosmosDbConfig.DatabaseName));
            // AspNet Identity Core
            serviceCollection.AddIdentity<MainUser, MainRole>()
                             .AddEntityFrameworkStores<TravisCommsSqlDbContext>()
                             .AddDefaultTokenProviders()
                             .AddUserStore<UserStore<MainUser, MainRole, TravisCommsSqlDbContext>>();
            serviceCollection.AddIdentityCore<MainUser>(options => { });
            
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
    }
}

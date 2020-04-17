using TravisComms.Data.Repository.Bindings;
using TravisComms.Data.Repository.Extensions;
using TravisComms.Data.Repository.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TravisComms.Data.Repository
{
    public static class StartupDb
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, CosmosDbConfig cosmosDbConfig, SQLDbConfig sqlConnectionString)
        {
            //serviceCollection.AddDbContext<TravisCommsNoSqlDbContext>(opt => opt.UseCosmos(cosmosDbConfig.ServiceEndpoint, cosmosDbConfig.AuthKey, cosmosDbConfig.DatabaseName));
            serviceCollection.AddDbContextPool<TravisCommsSqlDbContext>(opt => opt.UseSqlServer(sqlConnectionString.ConnectionString));
            serviceCollection.AddIdentityCore<MainUser>(options => { });  
            serviceCollection.AddScoped<IUserStore<MainUser>, UserStore<MainUser, MainRole, TravisCommsSqlDbContext>>();
            serviceCollection.AddRepositories();
        }
    }
}

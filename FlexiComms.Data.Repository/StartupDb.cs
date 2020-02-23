using FlexiComms.Data.Repository.Bindings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlexiComms.Data.Repository
{
    public static class StartupDb
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, CosmosDbConfig cosmosDbConfig, SQLDbConfig sqlConnectionString)
        {
            serviceCollection.AddDbContext<FlexiCommsNoSqlDbContext>(opt => opt.UseCosmos(cosmosDbConfig.ServiceEndpoint, cosmosDbConfig.AuthKey, cosmosDbConfig.DatabaseName));
            serviceCollection.AddDbContextPool<FlexiCommsSqlDbContext>(opt => opt.UseSqlServer(sqlConnectionString.ConnectionString));
        }
    }
}

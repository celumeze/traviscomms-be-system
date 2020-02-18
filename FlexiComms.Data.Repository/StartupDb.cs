using FlexiComms.Data.Repository.Bindings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlexiComms.Data.Repository
{
    public static class StartupDb
    {
        public static void ConfigureServices(IServiceCollection serviceCollection, CosmosDbConfig cosmosDbConfig)
        {
            serviceCollection.AddDbContext<FlexiCommsDbContext>(opt => opt.UseCosmos(cosmosDbConfig.ServiceEndpoint, cosmosDbConfig.AuthKey, cosmosDbConfig.DatabaseName));
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using System;
using Microsoft.Azure.ServiceBus.Primitives;
using TravisComms.Messaging;

namespace TravisComms.Sender.Module
{
    public static class StartupMessenger
    {
        public static void ConfigureServiceBus(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<ServiceBusConnectionConfig>(configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}"));
            string connectionString = configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}:AzureServiceBusConnectionString").Value;
            string sharedAccessKey = configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}:SharedAccessKey").Value;
            string keyName = configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}:KeyName").Value;

            var serviceBus = Bus.Factory.CreateUsingAzureServiceBus(busConfig =>
            {
                var host = busConfig.Host(connectionString, hostConfig =>
                {
                    hostConfig.OperationTimeout = TimeSpan.FromSeconds(20);
                    hostConfig.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, sharedAccessKey);
                });
            });
            serviceCollection.AddMassTransit(config =>
            {
                config.AddBus(provider => serviceBus);
            });
            serviceCollection.AddServiceBusSettings(serviceBus);
        }
    }
}

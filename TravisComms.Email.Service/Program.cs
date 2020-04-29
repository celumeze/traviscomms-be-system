using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using TravisComms.Api;
using TravisComms.Email.Service.Helpers;
using TravisComms.Messaging;
using TravisComms.Messaging.Configuration;

namespace TravisComms.Email.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); ///builds and run a host
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config => config.AddUserSecrets(typeof(Startup).GetTypeInfo().Assembly))
                .ConfigureServices((hostContext, services) =>
                {
                    string connectionString = hostContext.Configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}:AzureServiceBusConnectionString").Value;
                    string sharedAccessKey = hostContext.Configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}:SharedAccessKey").Value;
                    string keyName = hostContext.Configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}:KeyName").Value;
                    string sendGridApiKey = hostContext.Configuration.GetSection($"{nameof(SendGridApiConfig)}:ApiKey").Value;
                    EmailSender.SendGridApiKey = sendGridApiKey;
                    string queueName = hostContext.Configuration.GetSection($"{nameof(ServiceBusConnectionConfig)}:EmailServiceConfig:QueueName").Value;
                    
                  
                    services.AddMassTransit(serviceCollectionConfig =>
                    {
                        serviceCollectionConfig.AddConsumer<VerifyEmailConsumer>();

                        serviceCollectionConfig.AddBus(serviceProvider =>
                        
                            Bus.Factory.CreateUsingAzureServiceBus(busConfig =>
                            {
                                busConfig.Host(connectionString, hostConfig =>
                                {
                                    hostConfig.OperationTimeout = TimeSpan.FromSeconds(20);
                                    hostConfig.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(keyName, sharedAccessKey);
                                });

                                //seting up queue consumer
                                busConfig.ReceiveEndpoint(queueName, configurator =>
                                {
                                    configurator.Consumer<VerifyEmailConsumer>(serviceProvider);
                                });
                            })
                        );
                    });          
                    services.AddHostedService<EmailServiceHost>();
                    //serviceBus.Start();
                });
    }
}

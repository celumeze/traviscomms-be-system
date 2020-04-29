using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace TravisComms.Sender.Module
{
    public static class ServiceBusExtensions
    {
        public static void  AddServiceBusSettings(this IServiceCollection services, IBusControl serviceBusFactory)
        {

            services.AddScoped<IEmailMessenger, EmailMessenger>();
            services.AddSingleton<IPublishEndpoint>(serviceBusFactory);
            services.AddSingleton<ISendEndpointProvider>(serviceBusFactory);
            services.AddSingleton<IBus>(serviceBusFactory);

        }
    }
}

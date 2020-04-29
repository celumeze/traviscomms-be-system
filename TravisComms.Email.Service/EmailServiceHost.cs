using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TravisComms.Messaging;

namespace TravisComms.Email.Service
{

    public class EmailServiceHost : IHostedService
    {
        private readonly ILogger<EmailServiceHost> _logger;
        private readonly IBusControl _serviceBus;

        public EmailServiceHost(ILogger<EmailServiceHost> logger, IBusControl serviceBus)
        {
            _logger = logger;
            _serviceBus = serviceBus;
        }      

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Starting email service host..");
            await _serviceBus.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Stopping email service host..");
            await _serviceBus.StopAsync(cancellationToken);
        }
    }
}

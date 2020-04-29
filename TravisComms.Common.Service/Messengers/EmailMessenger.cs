using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using MassTransit;
using System;
using TravisComms.Messaging;
using TravisComms.Messaging.Interfaces;

namespace TravisComms.Sender.Module
{
    public class EmailMessenger : IEmailMessenger
    {
        private readonly IBus _serviceBus;
        private readonly ILogger<EmailMessenger> _logger;
        public EmailMessenger(ILogger<EmailMessenger> logger, IBus serviceBus) 
        {
            _serviceBus = serviceBus;
            _logger = logger;
        }

        public async Task SendVerifyEmailCommand(IVerifyEmailCommand emailMessage, 
                                           string connectionString, 
                                           string queuePath)
        {

            _logger.LogInformation($"Sending Verification Email to {emailMessage.EmailAddress}");
            var sendUri = new Uri($"{connectionString}{queuePath}");
            var endpoint = await _serviceBus.GetSendEndpoint(sendUri);
            await endpoint.Send<IVerifyEmailCommand>(emailMessage);          
        }
    }
}

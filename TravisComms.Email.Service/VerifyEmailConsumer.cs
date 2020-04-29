using MassTransit;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using TravisComms.Email.Service.Helpers;
using TravisComms.Messaging;
using TravisComms.Messaging.Interfaces;

namespace TravisComms.Email.Service
{
    public class VerifyEmailConsumer : IConsumer<IVerifyEmailCommand>
    {        
        public async Task Consume(ConsumeContext<IVerifyEmailCommand> context)
        {
            await EmailSender.SendEmailWithSendGridAsync(context.Message.EmailAddress, context.Message.CallbackUrl);
        }
    }
}

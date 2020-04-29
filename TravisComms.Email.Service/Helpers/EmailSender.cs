using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Email.Service.Helpers
{
    public static class EmailSender
    {
        public static string SendGridApiKey {get;set;}
        public static async Task SendEmailWithSendGridAsync(string emailAddress, string callbackUrl)
        {
            var client = new SendGridClient(SendGridApiKey);
            var msg = new SendGridMessage
            {
                From = new EmailAddress("charleselumeze@gmail.com", "TravisComms"),
                Subject = "TravisComms Email Verification",
                PlainTextContent = "Please verify your email",
                HtmlContent = $"Please verify your email <a src='{callbackUrl}'>here</a>",
            };
            msg.AddTo(new EmailAddress(emailAddress));
            msg.SetClickTracking(false, false);

             await client.SendEmailAsync(msg);
        }
    }
}

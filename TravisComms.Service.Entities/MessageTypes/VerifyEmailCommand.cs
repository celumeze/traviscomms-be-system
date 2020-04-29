using System;
using System.Collections.Generic;
using System.Text;
using TravisComms.Messaging.Interfaces;

namespace TravisComms.Messaging.MessageTypes
{
    public class VerifyEmailCommand : IVerifyEmailCommand
    {
        public Guid CorrelationID { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string CallbackUrl { get; set; }

    }
}

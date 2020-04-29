using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Messaging.Interfaces
{
    public interface IVerifyEmailCommand
    {
        Guid CorrelationID { get; }
        string EmailAddress { get; }
        string FirstName { get; }
        string CallbackUrl { get; }
    }
}

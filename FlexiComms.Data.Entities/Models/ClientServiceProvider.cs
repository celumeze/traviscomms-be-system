using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Entities.Models
{
    public class ClientServiceProvider
    {
        public Guid ClientServiceProviderId { get; set; }
        public string AuthToken { get; set; }
        public string AccountSid { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ServiceProviderId { get; set; }

        public ServiceProvider ServiceProvider { get; set; }
    }
}

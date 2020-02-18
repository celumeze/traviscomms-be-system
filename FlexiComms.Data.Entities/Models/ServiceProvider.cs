using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Entities.Models
{
    public class ServiceProvider
    {
        public Guid ServiceProviderId { get; set; }
        public string Name { get; set; }
        public string AuthToken { get; set; }
        public string AccountSid { get; set; }
        public string PhoneNumber { get; set; }
    }
}

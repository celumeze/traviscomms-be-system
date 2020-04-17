using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Entities.Models
{
    public class AccountHolderServiceProvider
    {
        public Guid AccountHolderServiceProviderId { get; set; }
        public string AuthToken { get; set; }
        public string AccountSid { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ServiceProviderId { get; set; }

        public ServiceProvider ServiceProvider { get; set; }
    }
}

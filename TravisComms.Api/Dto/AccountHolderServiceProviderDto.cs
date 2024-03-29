﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Api.Dto
{
    public class AccountHolderServiceProviderDto
    {
        public Guid AccountHolderServiceProviderId { get; set; }
        public string AuthToken { get; set; }
        public string AccountSid { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ServiceProviderId { get; set; }

        public ServiceProviderDto ServiceProvider { get; set; }
    }
}

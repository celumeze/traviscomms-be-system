using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Api.Dto
{
    public class ClientServiceProviderDto
    {
        public Guid ClientServiceProviderId { get; set; }
        public string AuthToken { get; set; }
        public string AccountSid { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ServiceProviderId { get; set; }

        public ServiceProviderDto ServiceProvider { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Api.Dto
{
    public class ServiceProviderDto
    {
        public Guid ServiceProviderId { get; set; }
        public string Name { get; set; }

        public List<AccountHolderServiceProviderDto> ClientServiceProviders { get; set; }
    }
}

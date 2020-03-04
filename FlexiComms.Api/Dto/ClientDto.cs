using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Api.Dto
{
    public class ClientDto
    {
        public Client()
        {
            Companies = new List<Company>();
        }
        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public Guid ClientRoleId { get; set; }

        public List<CompanyDto> Companies { get; set; }
        public ClientServiceProviderDto ClientServiceProvider { get; set; }
        public SubscriptionTypeDto SubscriptionType { get; set; }
        public ClientRoleDto ClientRole { get; set; }
    }
}

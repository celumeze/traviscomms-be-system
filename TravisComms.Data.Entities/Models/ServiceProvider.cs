using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Entities.Models
{
    public class ServiceProvider : EntityBase
    {
        public Guid ServiceProviderId { get; set; }
        public string Name { get; set; }

        public List<ClientServiceProvider> ClientServiceProviders { get; set; }
    }
}

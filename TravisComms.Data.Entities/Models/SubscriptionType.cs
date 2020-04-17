using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Entities.Models
{
    public class SubscriptionType : EntityBase
    {
        public Guid SubscriptionTypeId { get; set; }
        public string Name { get; set; }

        public List<Client> Clients { get; set; }
    }
}

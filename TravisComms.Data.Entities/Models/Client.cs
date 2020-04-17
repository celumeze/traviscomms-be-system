using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Entities.Models
{
    public class Client
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

        public List<Company> Companies { get; set; }
        public ClientServiceProvider ClientServiceProvider { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public ClientRole ClientRole { get; set; }
    }
}

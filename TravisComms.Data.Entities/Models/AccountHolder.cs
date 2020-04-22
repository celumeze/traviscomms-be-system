using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Entities.Models
{
    public class AccountHolder
    {
        public AccountHolder()
        {
            Companies = new List<Company>();
        }
        public Guid AccountHolderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public bool IsAccountDeleted { get; set; }
        public bool IsUpgradedToPaid { get; set; }
        public DateTime? DateOfUpgrade { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public Guid AccountHolderRoleId { get; set; }

        public List<Company> Companies { get; set; }
        public AccountHolderServiceProvider AccountHolderServiceProvider { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public AccountHolderRole AccountHolderRole { get; set; }
    }
}

using Org.IdentityServer.Enums;
using System;
using System.Collections.Generic;

namespace Org.IdentityServer.Models
{
    public class AccountHolderRole : EntityBase
    {
        public Guid AccountHolderRoleId { get; set; }
        public RoleType RoleType { get; set; }

        public List<AccountHolder> AccountHolders { get; set; }
    }
}

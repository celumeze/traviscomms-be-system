using TravisComms.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Entities.Models
{
    public class AccountHolderRole : EntityBase
    {
        public Guid AccountHolderRoleId { get; set; }
        public RoleType RoleType { get; set; }

        public List<AccountHolder> AccountHolders { get; set; }
    }
}

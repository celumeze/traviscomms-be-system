using FlexiComms.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Entities.Models
{
    public class ClientRole : EntityBase
    {
        public Guid ClientRoleId { get; set; }
        public RoleType RoleType { get; set; }

        public List<Client> Clients { get; set; }
    }
}

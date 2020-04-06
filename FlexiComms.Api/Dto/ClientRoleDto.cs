using FlexiComms.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Api.Dto
{
    public class ClientRoleDto
    {
        public Guid ClientRoleId { get; set; }
        public RoleType RoleType { get; set; }
    }
}

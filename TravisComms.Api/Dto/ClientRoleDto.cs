using TravisComms.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Api.Dto
{
    public class ClientRoleDto
    {
        public Guid ClientRoleId { get; set; }
        public RoleType RoleType { get; set; }
    }
}

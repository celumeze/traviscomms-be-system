using FlexiComms.Data.Entities.Enums;
using FlexiComms.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository.Interfaces
{
    public interface IClientRoleRepository
    {
        Task<Guid> GetClientRoleIdByRoleTypeAsync(RoleType roleType);
    }
}

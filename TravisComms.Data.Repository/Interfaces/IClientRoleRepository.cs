using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface IClientRoleRepository
    {
        Task<Guid> GetClientRoleIdByRoleTypeAsync(RoleType roleType);
    }
}

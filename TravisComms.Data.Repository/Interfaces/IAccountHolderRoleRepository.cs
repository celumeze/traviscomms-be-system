using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Enums;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface IAccountHolderRoleRepository
    {
        Task<Guid> GetAccountHolderRoleIdByRoleTypeAsync(RoleType roleType);
    }
}

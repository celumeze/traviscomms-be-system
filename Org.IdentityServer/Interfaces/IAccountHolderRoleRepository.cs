using Org.IdentityServer.Enums;
using System;
using System.Threading.Tasks;

namespace Org.IdentityServer.Interfaces
{
    public interface IAccountHolderRoleRepository
    {
        Task<Guid> GetAccountHolderRoleIdByRoleTypeAsync(RoleType roleType);
    }
}

using Org.IdentityServer.Data;
using Org.IdentityServer.Enums;
using Org.IdentityServer.Interfaces;
using Org.IdentityServer.Models;
using System;
using System.Threading.Tasks;

namespace Org.IdentityServer.Repository
{
    public class AccountHolderRoleRepository : GenericRepository<AccountHolderRole>, IAccountHolderRoleRepository
    {
        public AccountHolderRoleRepository(TravisCommsIdentityDbContext travisCommsIdentityDbContext) : base(travisCommsIdentityDbContext)
        {

        }

        public async Task<Guid> GetAccountHolderRoleIdByRoleTypeAsync(RoleType roleType)
        {
            var accountHolderRole = await base.FindAsync(a => a.RoleType == roleType);
            return accountHolderRole != null ? accountHolderRole.AccountHolderRoleId : Guid.Empty;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Data.Repository.Repository
{
    public class AccountHolderRoleRepository : RepositoryBase, IAccountHolderRoleRepository
    {
        private readonly TravisCommsSqlDbContext _TravisCommsSqlDbContext;
        public AccountHolderRoleRepository(TravisCommsSqlDbContext TravisCommsSqlDbContext) : base(TravisCommsSqlDbContext)
        {

        }

        public async Task<Guid> GetAccountHolderRoleIdByRoleTypeAsync(RoleType roleType)
        {
            var accountHolderRole = await _TravisCommsSqlDbContext.AccountHoldersRole?.Where(a => a.RoleType == roleType).FirstOrDefaultAsync();
            return accountHolderRole != null ? accountHolderRole.AccountHolderRoleId : Guid.Empty;
        }
    }
}

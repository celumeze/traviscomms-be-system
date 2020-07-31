using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Data.Repository.Repository
{
    public class AccountHolderRoleRepository : GenericRepository<AccountHolderRole>, IAccountHolderRoleRepository
    {
        public AccountHolderRoleRepository(TravisCommsSqlDbContext travisCommsSqlDbContext) : base(travisCommsSqlDbContext)
        {

        }

        public async Task<Guid> GetAccountHolderRoleIdByRoleTypeAsync(RoleType roleType)
        {
            var accountHolderRole = await base.FindAsync(a => a.RoleType == roleType);
            return accountHolderRole != null ? accountHolderRole.AccountHolderRoleId : Guid.Empty;
        }
    }
}

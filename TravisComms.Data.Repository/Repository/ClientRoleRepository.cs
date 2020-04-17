using TravisComms.Data.Entities.Enums;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Repository
{
    public class ClientRoleRepository : RepositoryBase, IClientRoleRepository
    {
        private readonly TravisCommsSqlDbContext _TravisCommsSqlDbContext;
        public ClientRoleRepository(TravisCommsSqlDbContext TravisCommsSqlDbContext) : base(TravisCommsSqlDbContext)
        {
            _TravisCommsSqlDbContext = TravisCommsSqlDbContext;
        }

        public async Task<Guid> GetClientRoleIdByRoleTypeAsync(RoleType roleType)
        {
            var clientRole = await _TravisCommsSqlDbContext.ClientRole?.Where(c => c.RoleType == roleType).FirstOrDefaultAsync();
            return clientRole != null ? clientRole.ClientRoleId : Guid.Empty;
        }
    }
}

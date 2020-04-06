using FlexiComms.Data.Entities.Enums;
using FlexiComms.Data.Entities.Models;
using FlexiComms.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository.Repository
{
    public class ClientRoleRepository : RepositoryBase, IClientRoleRepository
    {
        private readonly FlexiCommsSqlDbContext _flexiCommsSqlDbContext;
        public ClientRoleRepository(FlexiCommsSqlDbContext flexiCommsSqlDbContext) : base(flexiCommsSqlDbContext)
        {
            _flexiCommsSqlDbContext = flexiCommsSqlDbContext;
        }

        public async Task<Guid> GetClientRoleIdByRoleTypeAsync(RoleType roleType)
        {
            var clientRole = await _flexiCommsSqlDbContext.ClientRole?.Where(c => c.RoleType == roleType).FirstOrDefaultAsync();
            return clientRole != null ? clientRole.ClientRoleId : Guid.Empty;
        }
    }
}

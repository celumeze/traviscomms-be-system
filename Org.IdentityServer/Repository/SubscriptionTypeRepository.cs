using Org.IdentityServer.Data;
using Org.IdentityServer.Interfaces;
using Org.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.IdentityServer.Repository
{
    public class SubscriptionTypeRepository : GenericRepository<SubscriptionType>, ISubscriptionTypeRepository
    {
        public SubscriptionTypeRepository(TravisCommsIdentityDbContext travisCommsIdentityDbContext) : base(travisCommsIdentityDbContext)
        {

        }

        public async Task<Guid> GetSubscriptionIdByNameAsync(string name)
        {
            var result = await base.FindAsync(s => s.Name == name);
            return result != null ? result.SubscriptionTypeId : Guid.Empty;
        }

        public async Task<IEnumerable<SubscriptionType>> GetSubscriptionTypesAsync()
        {
            return await base.AllAsync();
        }
    }
}

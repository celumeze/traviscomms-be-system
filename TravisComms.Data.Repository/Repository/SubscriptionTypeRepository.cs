using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Repository
{
    public class SubscriptionTypeRepository : GenericRepository<SubscriptionType>, ISubscriptionTypeRepository
    {
        public SubscriptionTypeRepository(TravisCommsSqlDbContext travisCommsSqlDbContext) : base(travisCommsSqlDbContext)
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

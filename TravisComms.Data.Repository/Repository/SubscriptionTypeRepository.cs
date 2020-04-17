using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Repository
{
    public class SubscriptionTypeRepository : RepositoryBase, ISubscriptionTypeRepository
    {
        private readonly TravisCommsSqlDbContext _TravisCommsSqlDbContext;

        public SubscriptionTypeRepository(TravisCommsSqlDbContext TravisCommsSqlDbContext) : base(TravisCommsSqlDbContext)
        {
            _TravisCommsSqlDbContext = TravisCommsSqlDbContext;
        }
        public async Task<Guid> GetSubscriptionIdByNameAsync(string name)
        {
            var result = await _TravisCommsSqlDbContext.SubscriptionTypes?.FirstOrDefaultAsync(s => s.Name == name);
            return result != null ? result.SubscriptionTypeId : Guid.Empty;
        }

        public async Task<IEnumerable<SubscriptionType>> GetSubscriptionTypesAsync()
        {
            return await _TravisCommsSqlDbContext.SubscriptionTypes?.ToListAsync();
        }
    }
}

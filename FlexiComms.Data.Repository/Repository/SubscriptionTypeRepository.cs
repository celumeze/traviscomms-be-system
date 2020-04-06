using FlexiComms.Data.Entities.Models;
using FlexiComms.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlexiComms.Data.Repository.Repository
{
    public class SubscriptionTypeRepository : RepositoryBase, ISubscriptionTypeRepository
    {
        private readonly FlexiCommsSqlDbContext _flexiCommsSqlDbContext;

        public SubscriptionTypeRepository(FlexiCommsSqlDbContext flexiCommsSqlDbContext) : base(flexiCommsSqlDbContext)
        {
            _flexiCommsSqlDbContext = flexiCommsSqlDbContext;
        }
        public async Task<Guid> GetSubscriptionIdByNameAsync(string name)
        {
            var result = await _flexiCommsSqlDbContext.SubscriptionTypes?.FirstOrDefaultAsync(s => s.Name == name);
            return result != null ? result.SubscriptionTypeId : Guid.Empty;
        }

        public async Task<IEnumerable<SubscriptionType>> GetSubscriptionTypesAsync()
        {
            return await _flexiCommsSqlDbContext.SubscriptionTypes?.ToListAsync();
        }
    }
}

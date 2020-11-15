using Org.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.IdentityServer.Interfaces
{
    public interface ISubscriptionTypeRepository
    {
        Task<Guid> GetSubscriptionIdByNameAsync(string name);
        Task<IEnumerable<SubscriptionType>> GetSubscriptionTypesAsync();
    }
}

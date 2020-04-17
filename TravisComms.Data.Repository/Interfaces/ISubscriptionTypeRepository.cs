using TravisComms.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravisComms.Data.Repository.Interfaces
{
    public interface ISubscriptionTypeRepository
    {
        Task<Guid> GetSubscriptionIdByNameAsync(string name);
        Task<IEnumerable<SubscriptionType>> GetSubscriptionTypesAsync();
    }
}

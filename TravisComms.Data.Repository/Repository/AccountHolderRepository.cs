using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Data.Repository.Repository
{
    public class AccountHolderRepository : GenericRepository<AccountHolder>, IAccountHolderRepository
    {
        public AccountHolderRepository(TravisCommsSqlDbContext travisCommsSqlDbContext) : base(travisCommsSqlDbContext)
        {

        }
        public AccountHolder AddAccountHolder(AccountHolder accountHolder)
        {
            accountHolder.AccountHolderId = Guid.NewGuid();
            return base.Add(accountHolder);
        }

        public async Task<AccountHolder> GetAccountHolderByIdAsync(Guid accountHolderId)
        {
            return await base.GetAsync(accountHolderId);
        }

        public async Task<IEnumerable<AccountHolder>> GetAccountHoldersAsync()
        {
            return await base.AllAsync();
        }

        public async Task<IEnumerable<AccountHolder>> GetAccountHoldersBySubscriptionTypeAsync(Guid subscriptionTypeId)
        {
            return await base.FindAllAsync(a => a.SubscriptionTypeId == subscriptionTypeId);
        }

        public AccountHolder RemoveAccountHolder(AccountHolder accountHolder)
        {
            return base.Delete(accountHolder);
        }

        public AccountHolder UpdateAccountHolder(AccountHolder accountHolder)
        {
            return base.Update(accountHolder);
        }
    }
}

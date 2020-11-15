using Org.IdentityServer.Data;
using Org.IdentityServer.Interfaces;
using Org.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.IdentityServer.Repository
{
    public class AccountHolderRepository : GenericRepository<AccountHolder>, IAccountHolderRepository
    {
        public AccountHolderRepository(TravisCommsIdentityDbContext travisCommsIdDbContext) : base(travisCommsIdDbContext)
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

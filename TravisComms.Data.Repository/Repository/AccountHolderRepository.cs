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
    public class AccountHolderRepository : RepositoryBase, IAccountHolderRepository
    {
        private readonly TravisCommsSqlDbContext _TravisCommsSqlDbContext;
        public AccountHolderRepository(TravisCommsSqlDbContext TravisCommsSqlDbContext) : base(TravisCommsSqlDbContext)
        {
            _TravisCommsSqlDbContext = TravisCommsSqlDbContext;
        }

        public AccountHolder AddAccountHolder(AccountHolder accountHolder)
        {
            accountHolder.AccountHolderId = Guid.NewGuid();
            _TravisCommsSqlDbContext.Entry(accountHolder).State = EntityState.Added;
            return accountHolder;
        }

        public async Task<AccountHolder> GetAccountHolderByIdAsync(Guid accountHolderId)
        {
            return await _TravisCommsSqlDbContext.AccountHolders?.FirstOrDefaultAsync(a => a.AccountHolderId == accountHolderId);
        }

        public async Task<IEnumerable<AccountHolder>> GetAccountHoldersAsync()
        {
            return await _TravisCommsSqlDbContext.AccountHolders?.ToListAsync();
        }

        public async Task<IEnumerable<AccountHolder>> GetAccountHoldersBySubscriptionTypeAsync(Guid subscriptionTypeId)
        {
            return await _TravisCommsSqlDbContext.AccountHolders?.Where(c => c.SubscriptionTypeId == subscriptionTypeId).ToListAsync();
        }

        public AccountHolder RemoveAccountHolder(AccountHolder accountHolder)
        {
            _TravisCommsSqlDbContext.Entry(accountHolder).State = EntityState.Deleted;
            return accountHolder;
        }

        public AccountHolder UpdateAccountHolder(AccountHolder accountHolder)
        {
            _TravisCommsSqlDbContext.Entry(accountHolder).State = EntityState.Modified;
            return accountHolder;
        }
    }
}

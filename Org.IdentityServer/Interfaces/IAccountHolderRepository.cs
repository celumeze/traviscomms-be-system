using Org.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.IdentityServer.Interfaces
{
    public interface IAccountHolderRepository
    {
        Task<IEnumerable<AccountHolder>> GetAccountHoldersAsync();
        Task<AccountHolder> GetAccountHolderByIdAsync(Guid accountHolderId);
        Task<IEnumerable<AccountHolder>> GetAccountHoldersBySubscriptionTypeAsync(Guid subscriptionTypeId);
        AccountHolder AddAccountHolder(AccountHolder accountHolder);
        AccountHolder UpdateAccountHolder(AccountHolder accountHolder);
        AccountHolder RemoveAccountHolder(AccountHolder accountHolder);
    }
}

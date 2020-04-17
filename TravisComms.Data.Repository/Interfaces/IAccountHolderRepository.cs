using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;

namespace TravisComms.Data.Repository.Interfaces
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

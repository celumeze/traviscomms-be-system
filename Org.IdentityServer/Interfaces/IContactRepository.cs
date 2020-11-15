using Org.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.IdentityServer.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactDetailsAsync(string accountHolderId);
        Task<Contact> AddContactDetails(Contact contactDetails);
        Task<dynamic> AddBatchContactDetails(IEnumerable<dynamic> lstContactDetails, Guid accountHolderId);
        Task<Contact> EditContactDetails(Contact contactDetails);
        Task<IEnumerable<Contact>> DeleteContactDetails(IEnumerable<Contact> lstContactDetails, Guid accountHolder);
        Task<bool> DeleteAllContactDetails(Guid accountHolder);
    }
}

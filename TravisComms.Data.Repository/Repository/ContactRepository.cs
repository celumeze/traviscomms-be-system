using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Repository.Helpers;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Data.Repository.Repository
{
    public class ContactRepository : IContactRepository
    {
        public async Task<Contact> AddContactDetails(Contact contactDetails)
        {
            await CosmosHelper.CreateStoredPocedure(StoreConstants.InsertStoredProc, StoreConstants.ContactDbId, StoreConstants.ContactContainerId);
            return await CosmosHelper.Execute_spInsertContactDetails(StoreConstants.InsertStoredProc, StoreConstants.ContactDbId, StoreConstants.ContactContainerId, contactDetails);
        }

        public Task<IEnumerable<Contact>> GetContactDetailsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

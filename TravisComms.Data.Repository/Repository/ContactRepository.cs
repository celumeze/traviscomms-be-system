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
            return await CosmosHelper.Execute_spInsertContactDetails(StoreConstants.InsertStoredProc, StoreConstants.ContactDbId, StoreConstants.ContactContainerId, contactDetails);
        }

        public async Task<IEnumerable<dynamic>> GetContactDetailsAsync(string accountHolderId)
        {
            var sql = $"SELECT * FROM c WHERE c.accountHolderId = '{accountHolderId}'";
            var documents = await CosmosHelper.QueryDocuments(sql, StoreConstants.ContactDbId, StoreConstants.ContactContainerId);
            return documents;
        }
    }
}

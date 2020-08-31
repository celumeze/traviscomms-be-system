using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Entities.ServerSide;
using TravisComms.Data.Repository.Helpers;
using TravisComms.Data.Repository.Interfaces;

namespace TravisComms.Data.Repository.Repository
{
    public class ContactRepository : IContactRepository
    {
        public async Task<Contact> AddContactDetails(Contact contactDetails)
        {
            contactDetails.Id = Guid.NewGuid();
            var partitionKey = new PartitionKey(contactDetails.AccountHolderId.ToString());
            string json = await CosmosHelper.Execute_spInsertItem(StoreConstants.TravisCosmosDb, 
                                                                  StoreConstants.ContactContainerId, 
                                                                  contactDetails, partitionKey);

            if (!string.IsNullOrEmpty(json)) return JsonConvert.DeserializeObject<Contact>(json);
            return null;
        }

        public async Task<Contact> EditContactDetails(Contact contactDetails)
        {            
             var partitionKey = new PartitionKey(contactDetails.AccountHolderId.ToString());
             var cosmosDbItem = new CosmosDbItem
             {
                    AccountHolderId = contactDetails.AccountHolderId.ToString(),
                    Id = contactDetails.Id.ToString()
             };
             string json = await CosmosHelper.Execute_spUpdateItem(StoreConstants.TravisCosmosDb,
                                                                    StoreConstants.ContactContainerId,
                                                                    contactDetails, partitionKey, cosmosDbItem);
            if (!string.IsNullOrEmpty(json)) return JsonConvert.DeserializeObject<Contact>(json);
            else return null;
        }

        public async Task<IEnumerable<Contact>> GetContactDetailsAsync(string accountHolderId)
        {            
           var sql = $"SELECT * FROM c WHERE c.accountHolderId = '{accountHolderId}'";
           var documents = await CosmosHelper.QueryDocuments(sql, StoreConstants.TravisCosmosDb, StoreConstants.ContactContainerId);
           string json = JsonConvert.SerializeObject(documents);
           return JsonConvert.DeserializeObject<List<Contact>>(json);            
        }
    }
}

using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
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
        public async Task<dynamic> AddBatchContactDetails(IEnumerable<dynamic> lstContactDetails, Guid accountHolderId)
        {
            if(lstContactDetails != null)
            {
                var partitionKey = new PartitionKey(accountHolderId.ToString());
                string json = await CosmosHelper.Execute_spBulkInsertItems(StoreConstants.TravisCosmosDb,
                                                                      StoreConstants.ContactContainerId,
                                                                      lstContactDetails, partitionKey);
                if (!string.IsNullOrEmpty(json)) 
                    return JsonConvert.DeserializeObject<dynamic>(json, new ExpandoObjectConverter());
            }         
            return null;
        }

        public async Task<Contact> AddContactDetails(Contact contactDetails)
        {
            if(contactDetails != null)
            {
                var partitionKey = new PartitionKey(contactDetails.AccountHolderId.ToString());
                string json = await CosmosHelper.Execute_spInsertItem(StoreConstants.TravisCosmosDb,
                                                                      StoreConstants.ContactContainerId,
                                                                      contactDetails, partitionKey);

                if (!string.IsNullOrEmpty(json)) return JsonConvert.DeserializeObject<Contact>(json);
            }            
            return null;
        }

        public async Task<bool> DeleteAllContactDetails(Guid accountHolderId)
        {
            var partitionKey = new PartitionKey(accountHolderId.ToString());
            var cosmosDbItem = new CosmosDbItem
            {
                AccountHolderId = accountHolderId.ToString(),
            };
            bool isDeleted = await CosmosHelper.Execute_spBulkDeleteItems(StoreConstants.TravisCosmosDb,
                                                                  StoreConstants.ContactContainerId,
                                                                  partitionKey, cosmosDbItem);

            if (isDeleted) return true;
            return false;
        }

        public async Task<IEnumerable<Contact>> DeleteContactDetails(IEnumerable<Contact> lstContactDetails, Guid accountHolder)
        {
            if(lstContactDetails != null)
            {
                var partitionKey = new PartitionKey(accountHolder.ToString());
                List<string> contactDetailsId = new List<string>();

                foreach (var contact in lstContactDetails)
                {
                    contactDetailsId.Add(contact.Id.ToString());
                }
                await CosmosHelper.DeleteItems(StoreConstants.TravisCosmosDb, StoreConstants.ContactContainerId,
                                                contactDetailsId, partitionKey);
                return lstContactDetails;
            }
            return null;
        }
       
        public async Task<Contact> EditContactDetails(Contact contactDetails)
        {
            if(contactDetails != null)
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
            }
            return null;             
        }

        public async Task<IEnumerable<Contact>> GetContactDetailsAsync(string accountHolderId)
        {            
           var sql = $"{StoreConstants.SqlQueryForAccountHolderContacts}'{accountHolderId}'";
           var documents = await CosmosHelper.QueryDocuments(sql, StoreConstants.TravisCosmosDb, StoreConstants.ContactContainerId);
           string json = JsonConvert.SerializeObject(documents);
           return JsonConvert.DeserializeObject<List<Contact>>(json);            
        }
    }
}

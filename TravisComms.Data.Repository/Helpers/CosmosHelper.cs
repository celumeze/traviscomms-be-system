using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Scripts;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;
using TravisComms.Data.Entities.ServerSide;

namespace TravisComms.Data.Repository.Helpers
{
    public class CosmosHelper
    {
        public async static Task<dynamic> QueryDocuments(string sql, string databaseId, string containerId)
        {

            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            var iterator = container.GetItemQueryIterator<dynamic>(sql);
            var documents = await iterator.ReadNextAsync();           
            return documents;
        }

        public async static Task<dynamic> QueryDocumentsStateless(string databaseId, string containerId, string sql)
        {
            var continuationToken = default(string);
            do
            {
                var tokenResultPair = await QueryFetchNextPage(continuationToken, databaseId, containerId, sql);
                continuationToken = tokenResultPair.Key;
                return tokenResultPair.Value;

            } while (!string.IsNullOrEmpty(continuationToken));
        }

        public async static Task<string> Execute_spInsertItem(string databaseId, string containerId, object newObject, PartitionKey partitionKey)
        {
            await CosmosHelper.CreateStoredPocedure(StoreConstants.InsertStoredProc, databaseId, containerId);
            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            string newContactJson = JsonConvert.SerializeObject(newObject);
            var result = await container.Scripts.ExecuteStoredProcedureAsync<string>(StoreConstants.InsertStoredProc, partitionKey, new[] { newContactJson });
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return newContactJson;
            return null;
        }

        public async static Task<string> Execute_spBulkInsertItems(string databaseId, string containerId, IEnumerable<dynamic> newObject, PartitionKey partitionKey)
        {
            await CosmosHelper.CreateStoredPocedure(StoreConstants.InsertBatchStoredProc, databaseId, containerId);
            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            string newContactsJson = JsonConvert.SerializeObject(newObject);            
            var result = await container.Scripts.ExecuteStoredProcedureAsync<string>(StoreConstants.InsertBatchStoredProc, partitionKey, new[] { newContactsJson });
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return newContactsJson;
            return null;
        }

        public async static Task<string> Execute_spUpdateItem(string databaseId, string containerId, object updatedItem, PartitionKey partitionKey, CosmosDbItem cosmosDbItem)
        {
            await CosmosHelper.CreateStoredPocedure(StoreConstants.UpdateStoredProc, databaseId, containerId);
            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            string doc = JsonConvert.SerializeObject(updatedItem);
            var result = await container.Scripts.ExecuteStoredProcedureAsync<string>(StoreConstants.UpdateStoredProc, partitionKey, 
                                                 new[] { containerId, cosmosDbItem.Id, cosmosDbItem.AccountHolderId,  doc});
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return doc;
            return null;
        }

        #region Private Helper Methods
        private async static Task<KeyValuePair<string, dynamic>> QueryFetchNextPage(string continuationToken, string databaseId, string containerId, string sql)
        {
            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            var iterator = container.GetItemQueryIterator<dynamic>(sql, continuationToken);
            var page = await iterator.ReadNextAsync();
            continuationToken = page.ContinuationToken;
            return new KeyValuePair<string, dynamic>(continuationToken, page);
        }

        private async static Task CreateStoredPocedure(string sprocId, string databaseId, string containerId)
        {
            var parentDirectory = @"C:\Projects\TravisCommsCore\TravisComms.Data.Repository\CosmosServer";
            var sprocBody = File.ReadAllText(Path.Combine(parentDirectory, $"{sprocId}.js"));

            var sprocProps = new StoredProcedureProperties
            {
                Id = sprocId,
                Body = sprocBody
            };

            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            var iterator = container.Scripts.GetStoredProcedureQueryIterator<StoredProcedureProperties>();
            var sprocs = await iterator.ReadNextAsync();
            bool isFound = false;
            foreach (var sproc in sprocs)
            {
                if (sproc.Id == sprocId)
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                await container.Scripts.CreateStoredProcedureAsync(sprocProps);
            }
        }
        #endregion
    }
}

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Scripts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;

namespace TravisComms.Data.Repository.Helpers
{
    public class CosmosHelper
    {
        public async static Task<dynamic> QueryDocuments(string sql, string databaseId, string containerId)
        {

            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            var iterator = container.GetItemQueryIterator<dynamic>(sql);
            var documents = await iterator.ReadNextAsync();
            foreach (var contact in documents)
            {
                contact.accountHolderId = string.Empty;
            }
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

        public async static Task<Contact> Execute_spInsertContactDetails(string sprocId, string databaseId, string containerId, Contact newContact)
        {
            await CosmosHelper.CreateStoredPocedure(sprocId, databaseId, containerId);
            newContact.Id = Guid.NewGuid();
            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            var partitionKey = new PartitionKey(newContact.AccountHolderId.ToString());
            string newContactJson = JsonConvert.SerializeObject(newContact);
            var result = await container.Scripts.ExecuteStoredProcedureAsync<string>(sprocId, partitionKey, new[] { newContactJson });
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<Contact>(newContactJson);
            return null;
        }

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
    }
}

using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Scripts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TravisComms.Data.Entities.Models;

namespace TravisComms.Data.Repository.Helpers
{
    public class CosmosHelper
    {    

        public async static Task CreateStoredPocedure(string sprocId, string databaseId, string containerId)
        {
            var sprocBody = File.ReadAllText($@"..\TravisComms.Data.Repository\CosmosServer\{sprocId}.js");

            var sprocProps = new StoredProcedureProperties
            {
                Id = sprocId,
                Body = sprocBody
            };

            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            var iterator = container.Scripts.GetStoredProcedureQueryIterator<StoredProcedureProperties>();
            var sprocs = await iterator.ReadNextAsync();
            bool isFound = false;
            foreach(var sproc in sprocs)
            {
                if (sproc.Id == sprocId)
                {
                    isFound = true;
                    break;
                }                
            }
            if(!isFound)
            {
               await container.Scripts.CreateStoredProcedureAsync(sprocProps);
            }
                
        }

        public async static Task<Contact> Execute_spInsertContactDetails(string sprocId, string databaseId, string containerId, Contact newContact)
        {
            newContact.Id = Guid.NewGuid();
            var container = StartupDb.ApiCosmosClient.GetContainer(databaseId, containerId);
            var partitionKey = new PartitionKey(newContact.AccountHolderId.ToString());
            string newContactJson = JsonConvert.SerializeObject(newContact);
            var result =   await container.Scripts.ExecuteStoredProcedureAsync<string>(sprocId, partitionKey, new[] {newContactJson});
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
             return JsonConvert.DeserializeObject<Contact>(newContactJson);
            return null;
        }
    }
}

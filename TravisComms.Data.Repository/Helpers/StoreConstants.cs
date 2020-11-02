using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TravisComms.Data.Repository.Helpers
{
    public static class StoreConstants
    {
        public const string TravisCosmosDb = "TravisCommsCosmosDb";
        public const string ContactContainerId = "ContactDetails";
        public const string InsertStoredProc = "spInsert";
        public const string InsertBatchStoredProc = "spBulkInsert";
        public const string UpdateStoredProc = "spUpdate";
        public const string DeleteStoredProc = "spBulkDelete";
        public const string StoredProceduresFolder = @"\TravisComms.Data.Repository\CosmosServer";
        public const string SqlQueryForAccountHolderContacts = "SELECT * FROM c WHERE c.accountHolderId = ";
        public const string SqlQueryForSelectedAccountHolderContactsPrefix = "SELECT * FROM c WHERE c.id = ";
        public const string SqlQueryForSelectedAccountHolderContactsSuffix = "and c.accountHolderId = ";
    }
}

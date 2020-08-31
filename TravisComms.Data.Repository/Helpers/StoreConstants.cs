using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Data.Repository.Helpers
{
    public static class StoreConstants
    {
        public const string TravisCosmosDb = "TravisCommsCosmosDb";
        public const string ContactContainerId = "ContactDetails";
        public const string InsertStoredProc = "spInsert";
        public const string InsertBatchStoredProc = "spInsertBatch";
        public const string UpdateStoredProc = "spUpdate";
    }
}

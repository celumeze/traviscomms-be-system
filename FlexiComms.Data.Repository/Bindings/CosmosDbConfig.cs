using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Repository.Bindings
{
    public class CosmosDbConfig
    {
        public string ServiceEndpoint { get; set; }
        public string AuthKey { get; set; }
        public string DatabaseName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TravisComms.Messaging
{
    public class ServiceBusConnectionConfig
    {
        public string AzureServiceBusConnectionString { get; set; }
        public string KeyName { get; set; }
        public string SharedAccessKey { get; set; }
        public QueueConfig EmailServiceConfig { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Entities.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
    }
}

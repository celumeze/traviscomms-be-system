using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiComms.Data.Entities.Models
{
    public class Client
    {
        public Client()
        {
            Companies = new List<Company>();
        }
        public Guid ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Company> Companies { get; set; }
        public ClientServiceProvider ClientServiceProvider { get; set; }
    }
}

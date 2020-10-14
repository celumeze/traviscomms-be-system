using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TravisComms.Data.Entities.Models
{
    public class Contact
    {
        public Contact()
        {
            Id = Guid.NewGuid();
        }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "contactNumber")]
        public string ContactNumber { get; set; }
        [JsonProperty(PropertyName = "accountHolderId")]
        public Guid AccountHolderId { get; set; }
        [JsonProperty(PropertyName = "isUploadedFromCsv")]
        public bool IsUploadedFromCsv { get; set; }
        [JsonProperty(PropertyName = "isHeader")]
        public bool IsHeader { get; set; }     
    }
}

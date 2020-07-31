using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TravisComms.Data.Entities.Models
{
    public class Contact
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "contactNumber")]
        public string ContactNumber { get; set; }
        [JsonProperty(PropertyName = "customerAttribute1")]
        public string CustomerAttribute1 { get; set; }
        [JsonProperty(PropertyName = "customAttribute2")]
        public string CustomerAttribute2 { get; set; }
        [JsonProperty(PropertyName = "customAttribute3")]
        public string CustomerAttribute3 { get; set; }
        [JsonProperty(PropertyName = "customAttribute4")]
        public string CustomerAttribute4 { get; set; }
        [JsonProperty(PropertyName = "customAttribute5")]
        public string CustomerAttribute5 { get; set; }
        [JsonProperty(PropertyName = "customAttribute6")]
        public string CustomerAttribute6 { get; set; }
        [JsonProperty(PropertyName = "customAttribute7")]
        public string CustomerAttribute7 { get; set; }
        [JsonProperty(PropertyName = "customAttribute8")]
        public string CustomerAttribute8 { get; set; }
        [JsonProperty(PropertyName = "customAttribute9")]
        public string CustomerAttribute9 { get; set; }
        [JsonProperty(PropertyName = "customAttribute10")]
        public string CustomerAttribute10 { get; set; }
        [JsonProperty(PropertyName = "accountHolderId")]
        public Guid AccountHolderId { get; set; }
    }
}

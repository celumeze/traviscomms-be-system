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
        [JsonProperty(PropertyName = "customAttribute1")]
        public string CustomAttribute1 { get; set; }
        [JsonProperty(PropertyName = "customAttribute2")]
        public string CustomAttribute2 { get; set; }
        [JsonProperty(PropertyName = "customAttribute3")]
        public string CustomAttribute3 { get; set; }
        [JsonProperty(PropertyName = "customAttribute4")]
        public string CustomAttribute4 { get; set; }
        [JsonProperty(PropertyName = "customAttribute5")]
        public string CustomAttribute5 { get; set; }
        [JsonProperty(PropertyName = "customAttribute6")]
        public string CustomAttribute6 { get; set; }
        [JsonProperty(PropertyName = "customAttribute7")]
        public string CustomAttribute7 { get; set; }
        [JsonProperty(PropertyName = "customAttribute8")]
        public string CustomAttribute8 { get; set; }
        [JsonProperty(PropertyName = "customAttribute9")]
        public string CustomAttribute9 { get; set; }
        [JsonProperty(PropertyName = "customAttribute10")]
        public string CustomAttribute10 { get; set; }
        [JsonProperty(PropertyName = "accountHolderId")]
        public Guid AccountHolderId { get; set; }        
    }
}

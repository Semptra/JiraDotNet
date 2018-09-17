namespace Semptra.JiraDotNet.REST.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ProjectPropertyKeys
    {
        [JsonProperty("keys")]
        public ICollection<PropertyKey> PropertyKeys { get; set; }
    }
}
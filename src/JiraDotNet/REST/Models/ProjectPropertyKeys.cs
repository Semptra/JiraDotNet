using System.Collections.Generic;
using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class ProjectPropertyKeys
    {
        [JsonProperty("keys")]
        public ICollection<PropertyKey> PropertyKeys { get; set; }
    }
}
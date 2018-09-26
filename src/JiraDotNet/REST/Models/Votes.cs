using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Votes
    {
        public string Self { get; set; }

        [JsonProperty("votes")]
        public int Count { get; set; }

        public bool HasVoted { get; set; }
    }
}
using System;
using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public Uri Self { get; set; }

        public string Key { get; set; }

        [JsonProperty("fields")]
        public IssueFields IssueFields { get; set; }
    }
}
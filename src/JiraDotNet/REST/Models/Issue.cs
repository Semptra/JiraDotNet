namespace Semptra.JiraDotNet.REST.Models
{
    using System;
    using Newtonsoft.Json;

    public class Issue
    {
        public int Id { get; set; }

        public Uri Self { get; set; }

        public string Key { get; set; }

        [JsonProperty("fields")]
        public IssueFields IssueFields { get; set; }
    }
}
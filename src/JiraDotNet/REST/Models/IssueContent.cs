using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class IssueContent
    {
        public ContentType Type { get; set; }

        public string Text { get; set; }

        [JsonProperty("attrs")]
        public Attributes Attributes { get; set; }

        public ICollection<IssueContent> Content { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Semptra.JiraDotNet.REST.Models
{
    public class IssueDescription
    {
        public int Version { get; set; }

        public string Type { get; set; }

        public ICollection<IssueContent> Content { get; set; }
    }
}
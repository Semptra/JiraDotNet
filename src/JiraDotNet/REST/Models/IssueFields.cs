using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class IssueFields
    {
        [JsonRequired]
        public IssueType IssueType { get; set; }

        [JsonRequired]
        public Project Project { get; set; }

        [JsonRequired]
        public string Summary { get; set; }

        public string TimeSpent { get; set; }

        public ICollection<FixVersion> FixVersions { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? LastViewed { get; set; }

        public DateTime? Updated { get; set; }

        public Priority Priority { get; set; }

        public ICollection<string> Labels { get; set; }

        public Status Status { get; set; }

        public ICollection<Component> Components { get; set; }

        public IssueDescription Description { get; set; }

        public Account Creator { get; set; }

        public Account Reporter { get; set; }

        public Account Assignee { get; set; }

        public AggregateProgress AggregateProgress { get; set; }

        public IssueComment Comment { get; set; }

        public Votes Votes { get; set; }
    }
}
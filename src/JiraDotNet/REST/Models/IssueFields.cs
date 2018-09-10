namespace Semptra.JiraDotNet.REST.Models
{
    using System;
    using System.Collections.Generic;

    public class IssueFields
    {
        public IssueType IssueType { get; set; }

        public string TimeSpent { get; set; }

        public Project Project { get; set; }

        public ICollection<FixVersion> FixVersions { get; set; }

        public DateTime LastViewed { get; set; }

        public DateTime Created { get; set; }
    }
}
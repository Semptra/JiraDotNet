using System;

namespace Semptra.JiraDotNet.REST.Models
{
    public class IssueType
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public Uri IconUrl { get; set; }

        public string Subtask { get; set; }

        public string AvatarId { get; set; }
    }
}
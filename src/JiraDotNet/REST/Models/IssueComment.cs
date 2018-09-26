using System.Collections.Generic;
using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class IssueComment
    {
        public int StartAt { get; set; }

        public int Total { get; set; }

        public int MaxResults { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
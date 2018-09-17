using System;
using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class ProjectComponent
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Lead Lead { get; set; }

        public string AssigneeType { get; set; }

        public string RealAssigneeType { get; set; }

        public bool IsAssigneeTypeValid { get; set; }

        [JsonProperty("project")]
        public string ProjectKey { get; set; }

        public int ProjectId { get; set; }
    }
}
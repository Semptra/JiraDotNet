using System;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Lead
    {
        public Uri Self { get; set; }

        public string AccountId { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public AvatarUrls AvatarUrls { get; set; }

        public string DisplayName { get; set; }

        public bool Active { get; set; }
    }
}
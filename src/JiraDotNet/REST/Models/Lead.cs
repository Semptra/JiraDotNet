namespace Semptra.JiraDotNet.REST.Models
{
    using System;

    public class Lead
    {
        public Uri Self { get; set; }

        public string AccountId { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool Active { get; set; }
    }
}
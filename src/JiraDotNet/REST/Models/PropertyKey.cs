namespace Semptra.JiraDotNet.REST.Models
{
    using System;
    using System.Collections.Generic;

    public class PropertyKey
    {
        public string Self { get; set; }

        public string Key { get; set; }

        public IDictionary<string, string> Value { get; set; }
    }
}
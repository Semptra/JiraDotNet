using System;
using System.Collections.Generic;

namespace Semptra.JiraDotNet.REST.Models
{
    public class PropertyKey
    {
        public string Self { get; set; }

        public string Key { get; set; }

        public IDictionary<string, string> Value { get; set; }
    }
}
using System;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Priority
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Uri IconUrl { get; set; }
    }
}
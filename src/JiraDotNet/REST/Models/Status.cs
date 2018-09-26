using System;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Status
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Uri IconUrl { get; set; }

        public StatusCategory StatusCategory { get; set; }
    }
}
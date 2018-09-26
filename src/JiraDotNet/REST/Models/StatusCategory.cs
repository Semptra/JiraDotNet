using System;

namespace Semptra.JiraDotNet.REST.Models
{
    public class StatusCategory
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string ColorName { get; set; }
    }
}
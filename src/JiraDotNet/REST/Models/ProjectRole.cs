using System;
using System.Collections.Generic;

namespace Semptra.JiraDotNet.REST.Models
{
    public class ProjectRole
    {
        public Uri Self { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<Actor> Actors { get; set; }
    }
}
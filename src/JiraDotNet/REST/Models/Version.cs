
namespace Semptra.JiraDotNet.REST.Models
{
    using System;

    public class Version
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool Archived { get; set; }

        public bool Released { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime UserStartDate { get; set; }

        public DateTime UserReleaseDate { get; set; }

        public int ProjectId { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Comment
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public Account Author { get; set; }

        public Account UpdateAuthor { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Updated { get; set; }

        public bool JsdPublic { get; set; }

        public ICollection<IssueContent> Content { get; set; }
    }
}
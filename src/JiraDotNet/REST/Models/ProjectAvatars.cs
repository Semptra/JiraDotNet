namespace Semptra.JiraDotNet.REST.Models
{
    using System.Collections.Generic;

    public class ProjectAvatars
    {
        public ICollection<Avatar> System { get; set; }

        public ICollection<Avatar> Custom { get; set; }
    }
}
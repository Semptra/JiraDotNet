using System.Collections.Generic;

namespace Semptra.JiraDotNet.REST.Models
{
    public class ProjectAvatars
    {
        public ICollection<Avatar> System { get; set; }

        public ICollection<Avatar> Custom { get; set; }
    }
}
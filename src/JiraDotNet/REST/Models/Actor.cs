namespace Semptra.JiraDotNet.REST.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public ActorGroup ActorGroup { get; set; }
    }
}
namespace Semptra.JiraDotNet.REST.Models
{
    using Newtonsoft.Json;

    public class Avatar
    {
        public int Id { get; set; }

        public bool IsSystemAvatar { get; set; }

        public bool IsSelected { get; set; }

        public bool IsDeletable { get; set; }

        [JsonProperty("urls")]
        public AvatarUrls AvatarUrls { get; set; }

        public bool Selected { get; set; }
    }
}
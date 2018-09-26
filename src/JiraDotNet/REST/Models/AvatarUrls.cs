using Newtonsoft.Json;

namespace Semptra.JiraDotNet.REST.Models
{
    public class AvatarUrls
    {
        [JsonProperty("16x16")]
        public string ExtraSmall { get; set; }

        [JsonProperty("24x24")]
        public string Small { get; set; }

        [JsonProperty("32x32")]
        public string Medium { get; set; }

        [JsonProperty("48x48")]
        public string Original { get; set; }
    }
}
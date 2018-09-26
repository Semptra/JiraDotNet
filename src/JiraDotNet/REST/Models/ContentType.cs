using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Semptra.JiraDotNet.REST.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentType
    {
        [EnumMember(Value = "heading")]
        Heading,
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "paragraph")]
        Paragraph,
        [EnumMember(Value = "hardBreak")]
        HardBreak
    }
}
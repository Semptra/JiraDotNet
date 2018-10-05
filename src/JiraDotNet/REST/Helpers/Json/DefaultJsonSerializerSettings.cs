using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Semptra.JiraDotNet.REST.Helpers.Json
{
    internal static class DefaultJsonSerializerSettings
    {
        internal static JsonSerializerSettings Post =>
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new LowercaseContractResolver()
            };
    }
}
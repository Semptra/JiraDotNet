using Newtonsoft.Json.Serialization;

namespace Semptra.JiraDotNet.REST.Helpers.Json
{
    internal class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
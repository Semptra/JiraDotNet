using System.Collections.Generic;

namespace Semptra.JiraDotNet.REST.Extensions
{
    internal static class DictionaryExtensions
    {
        internal static void AddQueryParam(this Dictionary<string, string> dictionary, string name, string value)
        {
            if (dictionary != null && name != null && value != null)
            {
                dictionary.Add(name, value);
            }
        }

        internal static void AddQueryParams(this Dictionary<string, string> dictionary, string name, IEnumerable<string> values, string separator = ",")
        {
            if (dictionary != null && name != null && values != null)
            {
                dictionary.Add(name, string.Join(separator, values));
            }
        }
    }
}
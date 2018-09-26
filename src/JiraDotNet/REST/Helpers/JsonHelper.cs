using System;
using Newtonsoft.Json.Linq;

namespace Semptra.JiraDotNet.REST.Helpers
{
    internal static class JsonHelper
    {
        internal static bool IsValidJsonObject(string strInput)
        {
            strInput = strInput.Trim();

            if (strInput.StartsWith("{", System.StringComparison.InvariantCulture) &&
                strInput.EndsWith("}", System.StringComparison.InvariantCulture))
            {
                try
                {
                    var obj = JObject.Parse(strInput);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal static bool IsValidJsonArray(string strInput)
        {
            strInput = strInput.Trim();

            if (strInput.StartsWith("[", System.StringComparison.InvariantCulture) &&
                strInput.EndsWith("]", System.StringComparison.InvariantCulture))
            {
                try
                {
                    var arr = JArray.Parse(strInput);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
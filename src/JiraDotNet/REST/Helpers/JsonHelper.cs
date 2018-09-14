namespace Semptra.JiraDotNet.REST.Helpers
{
    using System;
    using Newtonsoft.Json.Linq;

    public static class JsonHelper
    {
        public static bool IsValidJsonObject(string strInput)
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

        public static bool IsValidJsonArray(string strInput)
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
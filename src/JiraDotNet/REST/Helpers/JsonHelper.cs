namespace Semptra.JiraDotNet.REST.Helpers
{
    using System;
    using Newtonsoft.Json.Linq;

    public static class JsonHelper
    {
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();

            if ((strInput.StartsWith("{", System.StringComparison.InvariantCulture) && strInput.EndsWith("}", System.StringComparison.InvariantCulture)) ||
                (strInput.StartsWith("[", System.StringComparison.InvariantCulture) && strInput.EndsWith("]", System.StringComparison.InvariantCulture)))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
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
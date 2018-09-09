namespace Semptra.JiraDotNet.REST.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    public static class UrlHelper
    {
        public static string ToUrl(string baseUrl, Dictionary<string, string> queryParams)
        {
            var builder = new UriBuilder(baseUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);

            foreach (KeyValuePair<string, string> queryParam in queryParams)
            {
                query.Add(queryParam.Key, queryParam.Value);
            }

            builder.Query = query.ToString();

            return builder.ToString();
        }
    }
}
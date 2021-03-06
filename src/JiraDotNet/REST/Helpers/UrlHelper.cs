﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Semptra.JiraDotNet.REST.Helpers
{
    internal static class UrlHelper
    {
        internal static string ToUrl(string baseUrl, Dictionary<string, string> queryParams)
        {
            var builder = new StringBuilder();

            builder.Append(baseUrl);

            if (baseUrl.Contains("?"))
            {
                builder.Append("&");
            }
            else if (!baseUrl.EndsWith("?", System.StringComparison.InvariantCulture) &&
                queryParams != null &&
                queryParams.Count != 0)
            {
                builder.Append("?");
            }

            foreach (var queryParam in queryParams)
            {
                builder.Append(queryParam.Key);
                builder.Append("=");
                builder.Append(HttpUtility.UrlEncode(queryParam.Value));
                builder.Append("&");
            }

            if (builder.ToString().EndsWith("&", System.StringComparison.InvariantCulture))
            {
                builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }
    }
}
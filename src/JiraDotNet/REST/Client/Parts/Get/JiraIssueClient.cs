using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semptra.JiraDotNet.REST.Extensions;
using Semptra.JiraDotNet.REST.Helpers;
using Semptra.JiraDotNet.REST.Helpers.Urls;
using Semptra.JiraDotNet.REST.Models;

namespace Semptra.JiraDotNet.REST.Client
{
    public partial class JiraClient
    {
        public async Task<Issue> GetIssueAsync(string issueIdOrKey,
            IEnumerable<string> fields = null, IEnumerable<string> properties = null)
        {
            string baseUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Issue.Get, issueIdOrKey);

            var queryParams = new Dictionary<string, string>();

            queryParams.AddQueryParams(JiraConstFields.QueryParams.Fields, fields);
            queryParams.AddQueryParams(JiraConstFields.QueryParams.Properties, properties);

            string issueUrl = UrlHelper.ToUrl(baseUrl, queryParams);

            return await this.GetEntityAsync<Issue>(issueUrl);
        }
    }
}
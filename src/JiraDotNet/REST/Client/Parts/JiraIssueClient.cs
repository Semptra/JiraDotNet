namespace Semptra.JiraDotNet.REST.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Semptra.JiraDotNet.REST.Helpers;
    using Semptra.JiraDotNet.REST.Helpers.Urls;
    using Semptra.JiraDotNet.REST.Models;

    public partial class JiraClient
    {
        public async Task<Issue> GetIssueAsync(
            string issueIdOrKey,
            IEnumerable<string> fields = null,
            IEnumerable<string> properties = null)
        {
            string baseUrl = string.Format(CultureInfo.InvariantCulture, this._jiraUrl + JiraUrls.Issue.Get, issueIdOrKey);

            var queryParams = new Dictionary<string, string>();

            if (fields != null)
            {
                queryParams.Add("fields", string.Join(",", fields));
            }

            if (properties != null)
            {
                queryParams.Add("properties", string.Join(",", properties));
            }

            string issueUrl = UrlHelper.ToUrl(baseUrl, queryParams);

            return await this.GetEntityAsync<Issue>(issueUrl);
        }
    }
}
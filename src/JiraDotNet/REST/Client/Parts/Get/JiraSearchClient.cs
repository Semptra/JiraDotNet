using System.Collections.Generic;
using System.Threading.Tasks;
using Semptra.JiraDotNet.REST.Extensions;
using Semptra.JiraDotNet.REST.Helpers;
using Semptra.JiraDotNet.REST.Helpers.Urls;
using Semptra.JiraDotNet.REST.Models;

namespace Semptra.JiraDotNet.REST.Client
{
    public partial class JiraClient
    {
        public async Task<ICollection<Issue>> SearchAsync(string jql, int startAt = 0, int maxResults = 50,
            int? totalResults = null, IEnumerable<string> fields = null, IEnumerable<string> properties = null)
        {
            var queryParams = new Dictionary<string, string>();

            queryParams.AddQueryParam(JiraConstFields.QueryParams.Jql, jql);
            queryParams.AddQueryParams(JiraConstFields.QueryParams.Fields, fields);
            queryParams.AddQueryParams(JiraConstFields.QueryParams.Properties, properties);

            string searchUrl = UrlHelper.ToUrl(JiraUrls.Search.Get, queryParams);

            return await this.GetEntitiesWithPaginationAsync<Issue>(searchUrl, startAt, maxResults, totalResults, "issues");
        }
    }
}
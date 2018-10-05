using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semptra.JiraDotNet.REST.Extensions;
using Semptra.JiraDotNet.REST.Helpers;
using Semptra.JiraDotNet.REST.Helpers.Json;
using Semptra.JiraDotNet.REST.Helpers.Urls;
using Semptra.JiraDotNet.REST.Models;

namespace Semptra.JiraDotNet.REST.Client
{
    public partial class JiraClient
    {
        public async Task<Issue> CreateIssueAsync(Issue issue)
        {
            string serializedContent = JsonConvert.SerializeObject(
                new { Fields = issue.IssueFields },
                DefaultJsonSerializerSettings.Post
                );

            string serializedCreatedIssue = await this.PostStringAsync(JiraUrls.Issue.Create, serializedContent);

            if (string.IsNullOrEmpty(serializedCreatedIssue))
            {
                throw new HttpRequestException("Cannot retrieve created Issue content.");
            }
            else
            {
                return JsonConvert.DeserializeObject<Issue>(serializedCreatedIssue);
            }
        }
    }
}
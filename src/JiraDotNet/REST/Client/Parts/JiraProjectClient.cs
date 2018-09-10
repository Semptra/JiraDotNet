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
        public async Task<Project> GetProjectAsync(string projectIdOrKey)
        {
            string projectUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.Get, projectIdOrKey);

            return await this.GetEntityAsync<Project>(projectUrl);
        }
    }
}
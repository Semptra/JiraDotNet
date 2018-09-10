namespace Semptra.JiraDotNet.REST.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Semptra.JiraDotNet.REST.Models;

    public interface IJiraClient : IDisposable
    {
        Task<HttpResponseMessage> ValidateConfigurationAsync();

        Task<Project> GetProjectAsync(string projectIdOrKey);

        Task<Issue> GetIssueAsync(string issueIdOrKey, IEnumerable<string> fields = null, IEnumerable<string> properties = null);
    }
}
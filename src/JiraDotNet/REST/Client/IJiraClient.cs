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

        Task<Issue> GetIssueAsync(string issueIdOrKey, IEnumerable<string> fields, IEnumerable<string> properties);
    }
}
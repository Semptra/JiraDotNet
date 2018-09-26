using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Semptra.JiraDotNet.REST.Helpers.Urls;
using Semptra.JiraDotNet.REST.Models;

namespace Semptra.JiraDotNet.REST.Client
{
    public partial class JiraClient
    {
        public async Task<ICollection<Status>> GetStatusesAsync()
        {
            return await this.GetEntitiesAsync<Status>(JiraUrls.Status.GetAll);
        }

        public async Task<Status> GetStatusAsync(string statusIdOrName)
        {
            string statusUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Status.Get, statusIdOrName);

            return await this.GetEntityAsync<Status>(statusUrl);
        }
    }
}
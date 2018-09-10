namespace Semptra.JiraDotNet.REST.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Semptra.JiraDotNet.REST.Helpers;

    public partial class JiraClient : IJiraClient
    {
        public JiraClient(string jiraBaseUrl, string username, string apiToken)
        {
            this._httpClient = new HttpClient
            {
                BaseAddress = new Uri(jiraBaseUrl)
            };

            this._httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            byte[] authCredentials = Encoding.ASCII.GetBytes($"{username}:{apiToken}");

            this._httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    scheme: "Basic",
                    parameter: Convert.ToBase64String(authCredentials));
        }

        private string _jiraUrl { get; }

        private HttpClient _httpClient { get; }

        public async Task<HttpResponseMessage> ValidateConfigurationAsync()
        {
            return await this._httpClient.GetAsync("/rest/api/3/project");
        }

        private async Task<IList<T>> GetEntitiesWithPaginationAsync<T>(string url, string valuesField)
        {
            List<T> entities = new List<T>();

            int current = 0;
            int totalResults = await this.GetTotalNumberOfEntitiesAsync(url);

            while (current < totalResults)
            {
                JObject jsonEntity = await this.GetJsonEntityAsync(url);

                current += jsonEntity["maxResults"].Value<int>();

                entities.AddRange(JsonConvert.DeserializeObject<ICollection<T>>(jsonEntity[valuesField].Value<string>()));
            }

            return entities;
        }

        private async Task<T> GetEntityAsync<T>(string url)
        {
            JObject jsonEntity = await this.GetJsonEntityAsync(url);

            return jsonEntity.ToObject<T>();
        }

        private async Task<JObject> GetJsonEntityAsync(string url)
        {
            string content = await this.GetAsStringAsync(url);

            if (!JsonHelper.IsValidJson(content))
            {
                throw new JsonParseException("Content is not a valid JSON");
            }

            return JObject.Parse(content);
        }

        private async Task<string> GetAsStringAsync(string url)
        {
            HttpResponseMessage responce = await _httpClient.GetAsync(url).ConfigureAwait(false);

            if (responce.StatusCode != HttpStatusCode.OK)
            {
                throw new JiraRequestException(responce);
            }

            return await responce.Content.ReadAsStringAsync();
        }

        private async Task<int> GetTotalNumberOfEntitiesAsync(string url)
        {
            JObject jsonResponce = await this.GetJsonEntityAsync(url);

            if (!jsonResponce.TryGetValue("total", out JToken totalValueToken))
            {
                return 0;
            }

            if (!int.TryParse(totalValueToken.Value<string>(), out int total))
            {
                return 0;
            }

            return total;
        }

        public void Dispose()
        {
            this._httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
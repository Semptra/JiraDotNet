using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semptra.JiraDotNet.REST.Helpers;
using Semptra.JiraDotNet.REST.Helpers.Json;
using Semptra.JiraDotNet.REST.Helpers.Urls;

namespace Semptra.JiraDotNet.REST.Client
{
    public partial class JiraClient : IJiraClient
    {
        public JiraClient(string jiraBaseUrl, string username, string apiToken)
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri(jiraBaseUrl)
            };

            this.httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(MediaTypes.ApplicationJson));

            byte[] authCredentials = Encoding.ASCII.GetBytes($"{username}:{apiToken}");

            this.httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    scheme: "Basic",
                    parameter: Convert.ToBase64String(authCredentials));
        }

        private HttpClient httpClient { get; }

        public async Task<HttpResponseMessage> ValidateConfigurationAsync()
        {
            return await this.httpClient.GetAsync(JiraUrls.Project.GetProjects);
        }

        private async Task<IList<T>> GetEntitiesWithPaginationAsync<T>(string url,
            int startAt, int maxResults, int? totalResults, string valuesField)
        {
            var entities = new List<T>();

            var queryParams = new Dictionary<string, string>
            {
                { JiraConstFields.Pagination.StartAt, startAt.ToString() },
                { JiraConstFields.Pagination.MaxResults, maxResults.ToString() }
            };

            int jiraTotalResults = await this.GetTotalNumberOfEntitiesAsync(url);

            totalResults = Math.Min(totalResults ?? jiraTotalResults, jiraTotalResults);

            if (totalResults < maxResults)
            {
                maxResults = totalResults.Value;
            }

            List<string> serializationErrors = new List<string>();

            while (startAt < totalResults)
            {
                queryParams[JiraConstFields.Pagination.StartAt] = startAt.ToString();
                queryParams[JiraConstFields.Pagination.MaxResults] = maxResults.ToString();

                JObject jsonEntity = await this.GetJsonObjectAsync(UrlHelper.ToUrl(url, queryParams));

                startAt += jsonEntity[JiraConstFields.Pagination.MaxResults].Value<int>();

                entities.AddRange(JsonConvert.DeserializeObject<ICollection<T>>(
                    jsonEntity.GetValue(valuesField).ToString(),
                    new JsonSerializerSettings
                    {
                        Error = (sender, args) =>
                        {
                            serializationErrors.Add(args.ErrorContext.Error.Message);
                            args.ErrorContext.Handled = true;
                        }
                    }));
            }

            if (serializationErrors.Count != 0)
            {
                throw new JsonSerializationException(string.Join(Environment.NewLine, serializationErrors));
            }

            return entities;
        }

        private async Task<int> GetTotalNumberOfEntitiesAsync(string url)
        {
            JObject jsonResponce = await this.GetJsonObjectAsync(url);

            if (!jsonResponce.TryGetValue(JiraConstFields.Pagination.Total, out JToken totalValueToken))
            {
                return 0;
            }

            if (!int.TryParse(totalValueToken.Value<string>(), out int total))
            {
                return 0;
            }

            return total;
        }

        private async Task<T> GetEntityAsync<T>(string url)
        {
            JObject jsonObject = await this.GetJsonObjectAsync(url);

            return jsonObject.ToObject<T>();
        }

        private async Task<ICollection<T>> GetEntitiesAsync<T>(string url)
        {
            JArray jsonArray = await this.GetJsonArrayAsync(url);

            return jsonArray.ToObject<ICollection<T>>();
        }

        private async Task<JObject> GetJsonObjectAsync(string url)
        {
            string content = await this.GetContentAsStringAsync(url);

            content = content.Replace("\\\\ \"", "\\\\\"");

            if (!JsonHelper.IsValidJsonObject(content))
            {
                throw new JsonParseException("Content is not a valid JSON Object");
            }

            return JObject.Parse(content);
        }

        private async Task<JArray> GetJsonArrayAsync(string url)
        {
            string content = await this.GetContentAsStringAsync(url);

            if (!JsonHelper.IsValidJsonArray(content))
            {
                throw new JsonParseException("Content is not a valid JSON Array");
            }

            return JArray.Parse(content);
        }

        private async Task<string> GetContentAsStringAsync(string url)
        {
            HttpResponseMessage responce = await this.httpClient.GetAsync(url).ConfigureAwait(false);

            if (responce.StatusCode != HttpStatusCode.OK)
            {
                throw new JiraRequestException(responce);
            }

            return await responce.Content.ReadAsStringAsync();
        }

        private async Task<string> PostStringAsync(string url, string stringContent)
        {
            var content = new StringContent(stringContent, Encoding.UTF8, Helpers.MediaTypes.ApplicationJson);

            HttpResponseMessage responce = await this.httpClient.PostAsync(url, content);

            if (!responce.IsSuccessStatusCode)
            {
                throw new JiraRequestException(responce);
            }

            if (responce.Content != null)
            {
                return await responce.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
        }

        void IDisposable.Dispose()
        {
            this.httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
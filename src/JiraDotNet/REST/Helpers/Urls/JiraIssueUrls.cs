namespace Semptra.JiraDotNet.REST.Helpers.Urls
{
    internal static partial class JiraUrls
    {
        internal static class Issue
        {
            internal const string Get = "/rest/api/3/issue/{0}";

            internal const string Create = "/rest/api/3/issue";
            internal const string BulkCreate = "/rest/api/3/issue/bulk";
        }
    }
}
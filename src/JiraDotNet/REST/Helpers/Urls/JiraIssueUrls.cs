namespace Semptra.JiraDotNet.REST.Helpers.Urls
{
    public static partial class JiraUrls
    {
        public static class Issue
        {
            public const string Get = "/rest/api/3/issue/{0}";

            public const string Create = "/rest/api/3/issue";
            public const string BulkCreate = "/rest/api/3/issue/bulk";
        }
    }
}
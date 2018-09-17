namespace Semptra.JiraDotNet.REST.Helpers.Urls
{
    public static partial class JiraUrls
    {
        public static class Project
        {
            public const string GetProjects = "/rest/api/3/project";
            public const string GetProject = "/rest/api/3/project/{0}";

            public const string GetProjectTypes = "/rest/api/3/project/type";
            public const string GetProjectType = "/rest/api/3/project/type/{0}";
            public const string GetAccessibleProjectType = "/rest/api/3/project/type/{0}/accessible";

            public const string GetProjectAvatars = "/rest/api/3/project/{0}/avatars";

            public const string GetProjectComponents = "/rest/api/3/project/{0}/components";

            public const string GetProjectPropertyKeys = "/rest/api/3/project/{0}/properties";
            public const string GetProjectPropertyKey = "/rest/api/3/project/{0}/properties/{1}";
        }
    }
}
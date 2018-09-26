namespace Semptra.JiraDotNet.REST.Helpers.Urls
{
    internal static partial class JiraUrls
    {
        internal static class Project
        {
            internal const string GetProjects = "/rest/api/3/project";
            internal const string GetProject = "/rest/api/3/project/{0}";

            internal const string GetProjectTypes = "/rest/api/3/project/type";
            internal const string GetProjectType = "/rest/api/3/project/type/{0}";
            internal const string GetAccessibleProjectType = "/rest/api/3/project/type/{0}/accessible";

            internal const string GetProjectAvatars = "/rest/api/3/project/{0}/avatars";

            internal const string GetProjectComponents = "/rest/api/3/project/{0}/components";

            internal const string GetProjectPropertyKeys = "/rest/api/3/project/{0}/properties";
            internal const string GetProjectPropertyKey = "/rest/api/3/project/{0}/properties/{1}";

            internal const string GetProjectRoles = "/rest/api/3/project/{0}/role";
            internal const string GetProjectRole = "/rest/api/3/project/{0}/role/{1}";
        }
    }
}
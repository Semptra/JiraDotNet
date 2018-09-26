using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Semptra.JiraDotNet.REST.Models;

namespace Semptra.JiraDotNet.REST.Client
{
    public interface IJiraClient : IDisposable
    {
        /// <summary>
        /// Validates if credentials is valid
        /// </summary>
        Task<HttpResponseMessage> ValidateConfigurationAsync();

        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-get
        /// </para>
        /// <para>
        /// Returns all projects visible to the currently logged in user. 
        /// For projects to be visible, the authenticated user must be granted either Browse projects or Administer projects permissions. 
        /// If no user is logged in, it returns all projects that are visible for anonymous users.
        /// </para>
        /// <para> 
        /// Permissions required: Browse Projects project permission. 
        /// </para>
        /// <para> 
        /// App scope required: READ 
        /// </para>
        /// </summary>
        Task<ICollection<Project>> GetProjectsAsync();
        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-projectIdOrKey-get
        /// </para>
        /// <para>
        /// Returns the project details for the specified project.
        /// </para>
        /// <para> 
        /// Permissions required: Browse Projects project permission. 
        /// </para>
        /// <para> 
        /// App scope required: READ 
        /// </para>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// </summary>
        Task<Project> GetProjectAsync(string projectIdOrKey);

        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/#api-api-3-project-type-get
        /// </para>
        /// <para>
        /// Returns all project types, whether or not the instance has a valid license for each type.
        /// </para>
        /// <para> 
        /// Permissions required: Permission to log in to Jira (that is, member of the users group).
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// </summary>
        Task<ICollection<ProjectType>> GetProjectTypesAsync();
        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/#api-api-3-project-type-projectTypeKey-get
        /// </para>
        /// <para>
        /// Returns a project type.
        /// </para>
        /// <para> 
        /// Permissions required: Permission to log in to Jira (that is, member of the users group).
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectTypeKey">The key of the project type. Valid values: business, service_desk, software</param>
        /// </summary>
        Task<ProjectType> GetProjectTypeAsync(string projectTypeKey);
        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/#api-api-3-project-type-projectTypeKey-accessible-get
        /// </para>
        /// <para>
        /// Returns a project type if it is accessible to the logged in user.
        /// </para>
        /// <para> 
        /// Permissions required: Permission to log in to Jira (that is, member of the users group).
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectTypeKey">The key of the project type. Valid values: business, service_desk, software</param>
        /// </summary>
        Task<ProjectType> GetAccessibleProjectType(string projectTypeKey);

        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-projectIdOrKey-avatars-get
        /// </para>
        /// <para>
        /// Returns all project avatars visible for the currently logged in user. The avatars are grouped into system avatars and custom avatars.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive). Project keys must start with an uppercase letter followed by one or more uppercase alphanumeric characters.</param>
        /// </summary>
        Task<ProjectAvatars> GetProjectAvatars(string projectIdOrKey);

        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-projectIdOrKey-components-get
        /// </para>
        /// <para>
        /// Returns all components existing in a single project. See the <see cref="IJiraClient.GetProjectComponentsPaginated(string)" /> resource if you want to get a full list of components with pagination.
        /// </para>
        /// <para>
        /// Permissions required: Browse Projects project permission.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// </summary>
        Task<ICollection<ProjectComponent>> GetProjectComponents(string projectIdOrKey);
        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="projectIdOrKey"></param>
        /// <returns></returns>
        Task<ICollection<ProjectComponent>> GetProjectComponentsPaginated(string projectIdOrKey);

        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-projectIdOrKey-properties-get
        /// </para>
        /// <para>
        /// Returns all project property keys for the project.
        /// </para>
        /// <para>
        /// Permissions required: Browse Projects project permission.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// </summary>
        Task<ProjectPropertyKeys> GetProjectPropertyKeys(string projectIdOrKey);
        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-projectIdOrKey-properties-propertyKey-get
        /// </para>
        /// <para>
        /// Returns the value of the project property.
        /// </para>
        /// <para>
        /// Permissions required: Browse Projects project permission.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="propertyKey">The project property key. Use <see cref="IJiraClient.GetProjectPropertyKeys(string)" /> to get a list of all project property keys.</param>
        /// </summary>
        Task<PropertyKey> GetProjectPropertyKey(string projectIdOrKey, string propertyKey);

        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-projectIdOrKey-role-get
        /// </para>
        /// <para>
        /// Returns a list of project roles for the project.
        /// Note that all project roles are shared with all projects in Jira Cloud.
        /// </para>
        /// <para>
        /// Permissions required: Administer Jira global permission or Administer Projects project permission.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// </summary>
        Task<IDictionary<string, string>> GetProjectRoles(string projectIdOrKey);
        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-project-projectIdOrKey-role-id-get
        /// </para>
        /// <para>
        /// Returns the project role's details and actors associated with the project. The list of actors is sorted by display name.
        /// </para>
        /// <para>
        /// Permissions required: Administer Jira global permission or Administer Projects project permission.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="projectIdOrKey">The project ID or project key (case sensitive).</param>
        /// <param name="roleId">The ID of the project role. Use <see cref="IJiraClient.GetProjectRoles(string)" /> to get a list of project role IDs.</param>
        /// </summary>
        Task<ProjectRole> GetProjectRole(string projectIdOrKey, int roleId);

        /// <summary>
        /// <para>
        /// https://developer.atlassian.com/cloud/jira/platform/rest/v3/?utm_medium=302#api-api-3-issue-issueIdOrKey-get
        /// </para>
        /// <para>
        /// Returns a project type if it is accessible to the logged in user.
        /// </para>
        /// <para> 
        /// Permissions required: Permission to log in to Jira (that is, member of the users group).
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="issueIdOrKey">ID or key of the issue, for example: JRACLOUD-1549. If exact match is not found then Jira will perform a case-insensitive search, and check for moved issues.</param>
        /// <param name="fields">Multi-value parameter defining the fields returned for the issue. By default, all fields are returned.</param>
        /// <param name="properties">Multi-value parameter defining the list of properties returned for the issue. Unlike fields, properties are not included in the response by default.</param>
        /// </summary>
        Task<Issue> GetIssueAsync(string issueIdOrKey,
            IEnumerable<string> fields = null, IEnumerable<string> properties = null);

        /// <summary>
        /// <para>
        /// Returns a list of all statuses associated with workflows.
        /// </para>
        /// <para>
        /// Permissions required: Browse projects project permission. Users with permission to access Jira can call this method, but an empty list is returned.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// </summary>
        Task<ICollection<Status>> GetStatusesAsync();
        /// <summary>
        /// <para>
        /// Returns a status. The status must be associated with a workflow to be returned.
        /// </para>
        /// <para>
        /// If a name is used on more than one status, only the status found first is returned. Therefore, identifying the status by its ID may be preferable.
        /// </para>
        /// <para>
        /// Permissions required: Browse projects project permission.
        /// </para>
        /// <para> 
        /// App scope required: READ
        /// </para>
        /// <param name="statusIdOrName">The ID or name of the status.</param>
        /// </summary>
        Task<Status> GetStatusAsync(string statusIdOrName);

        /// <summary>
        /// <para>
        /// Searches for issues using JQL. Permissions required: Permission to access Jira.
        /// If the JQL query expression is too large to be encoded as a query parameter, use the POST version of this resource.
        /// </para>
        /// <para>
        /// App scope required: READ
        /// </para>
        /// </summary>
        /// <param name="jql">A JQL expression. If no JQL expression is provided all issues are returned.</param>
        /// <param name="startAt">The index of the first item to return in the page of results (page offset).</param>
        /// <param name="maxResults">The maximum number of items to return per page. Maximum is 100.</param>
        /// <param name="totalResults">The total number of items to return. If this value is null, then all items returned.</param>
        /// <param name="fields">A comma-separated list of fields to return for each issue, use it to retrieve a subset of fields.</param>
        /// <param name="properties">A comma-separated list of up to 5 issue properties to include in the results.</param>
        Task<ICollection<Issue>> SearchAsync(string jql, int startAt = 0, int maxResults = 50,
            int? totalResults = null, IEnumerable<string> fields = null, IEnumerable<string> properties = null);
    }
}
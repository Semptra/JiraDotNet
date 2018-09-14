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
        /// <param name="projectIdOrKey">
        /// The project ID or project key (case sensitive).
        /// </param>
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
        /// <param name="projectTypeKey">
        /// The key of the project type. Valid values: business, service_desk, software
        /// </param>
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
        /// <param name="projectTypeKey">
        /// The key of the project type. Valid values: business, service_desk, software
        /// </param>
        /// </summary>
        Task<ProjectType> GetAccessibleProjectType(string projectTypeKey);

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
        /// <param name="issueIdOrKey">
        /// ID or key of the issue, for example: JRACLOUD-1549. If exact match is not found then Jira will perform a case-insensitive search, and check for moved issues.
        /// </param>
        /// <param name="fields">
        /// Multi-value parameter defining the fields returned for the issue. By default, all fields are returned.
        /// </param>
        /// <param name="properties">
        /// Multi-value parameter defining the list of properties returned for the issue. Unlike fields, properties are not included in the response by default.
        /// </param>
        /// </summary>
        Task<Issue> GetIssueAsync(string issueIdOrKey, IEnumerable<string> fields = null, IEnumerable<string> properties = null);
    }
}
namespace Semptra.JiraDotNet.REST.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Semptra.JiraDotNet.REST.Helpers;
    using Semptra.JiraDotNet.REST.Helpers.Urls;
    using Semptra.JiraDotNet.REST.Models;

    public partial class JiraClient
    {
        public async Task<ICollection<Project>> GetProjectsAsync()
        {
            return await this.GetEntitiesAsync<Project>(JiraUrls.Project.GetProjects);
        }

        public async Task<Project> GetProjectAsync(string projectIdOrKey)
        {
            string projectUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.GetProject, projectIdOrKey);

            return await this.GetEntityAsync<Project>(projectUrl);
        }

        public async Task<ICollection<ProjectType>> GetProjectTypesAsync()
        {
            return await this.GetEntitiesAsync<ProjectType>(JiraUrls.Project.GetProjectTypes);
        }

        public async Task<ProjectType> GetProjectTypeAsync(string projectTypeKey)
        {
            string projectTypeUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.GetProjectType, projectTypeKey);

            return await this.GetEntityAsync<ProjectType>(projectTypeUrl);
        }

        public async Task<ProjectType> GetAccessibleProjectType(string projectTypeKey)
        {
            string projectTypeUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.GetAccessibleProjectType, projectTypeKey);

            return await this.GetEntityAsync<ProjectType>(projectTypeUrl);
        }

        public async Task<ProjectAvatars> GetProjectAvatars(string projectIdOrKey)
        {
            string projectAvatarsUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.GetProjectAvatars, projectIdOrKey);

            return await this.GetEntityAsync<ProjectAvatars>(projectAvatarsUrl);
        }

        public async Task<ICollection<ProjectComponent>> GetProjectComponents(string projectIdOrKey)
        {
            string projectComponentsUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.GetProjectComponents, projectIdOrKey);

            return await this.GetEntitiesAsync<ProjectComponent>(projectComponentsUrl);
        }

        public async Task<ICollection<ProjectComponent>> GetProjectComponentsPaginated(string projectIdOrKey)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectPropertyKeys> GetProjectPropertyKeys(string projectIdOrKey)
        {
            string projectPropertyKeysUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.GetProjectPropertyKeys, projectIdOrKey);

            return await this.GetEntityAsync<ProjectPropertyKeys>(projectPropertyKeysUrl);
        }

        public async Task<PropertyKey> GetProjectPropertyKey(string projectIdOrKey, string propertyKey)
        {
            string projectPropertyKeyUrl = string.Format(CultureInfo.InvariantCulture, JiraUrls.Project.GetProjectPropertyKey, projectIdOrKey, propertyKey);

            return await this.GetEntityAsync<PropertyKey>(projectPropertyKeyUrl);
        }
    }
}
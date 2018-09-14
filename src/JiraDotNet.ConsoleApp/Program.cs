using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Semptra.JiraDotNet.REST.Client;
using Semptra.JiraDotNet.REST.Models;

namespace Semptra.JiraDotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Insert Jira URL, username and API Token to test JiraClient
            // Also insert IDs or Keys for entities and uncomment needed ones
            using (IJiraClient client = new JiraClient(
                jiraBaseUrl: "",
                username: "",
                apiToken: ""))
            {
                // GetAndLogEntity<ICollection<Project>>("Projects", client.GetProjectsAsync().Result);
                // GetAndLogEntity<Project>("Project", client.GetProjectAsync("").Result);

                // GetAndLogEntity<ICollection<ProjectType>>("Project Types", client.GetProjectTypesAsync().Result);
                // GetAndLogEntity<ProjectType>("Project Type", client.GetProjectTypeAsync("").Result);
                // GetAndLogEntity<ProjectType>("Accessible Project Type", client.GetAccessibleProjectType("").Result);

                // GetAndLogEntity<Issue>("Issue", client.GetIssueAsync("").Result);
            }
        }

        static void GetAndLogEntity<T>(string label, T entity)
        {
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            string labelFormat = new string('-', 10) + " {0} " + new string('-', 10);

            Console.WriteLine(string.Format(labelFormat, label));

            string jsonEntity = JsonConvert.SerializeObject(entity, Formatting.Indented);

            Console.WriteLine(jsonEntity);
            File.WriteAllText(Path.Combine(basePath, label + ".json"), jsonEntity);
        }
    }
}

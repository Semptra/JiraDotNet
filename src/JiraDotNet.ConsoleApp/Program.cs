using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            // Insert Jira URL, username and API Token to test JiraClient
            // Also insert IDs or Keys for entities and uncomment needed ones
            using (IJiraClient jiraClient = new JiraClient(
                jiraBaseUrl: "https://medavanteinc.atlassian.net",
                username: "osachek@medavante.com",
                apiToken: "F1qeveAHxLEV6Mij2hQP3ECD"))
            {
                ICollection<Status> statuses = await jiraClient.GetStatusesAsync();

                Console.WriteLine("Existing issues statuses:");
                foreach (var status in statuses.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"{status.Id.ToString().PadRight(6)} - {status.Name}");
                }

                Console.WriteLine();
                Console.Write("Select issue status (by ID or name): ");
                string statusIdOrName = Console.ReadLine();

                ICollection<Issue> issues = await jiraClient.SearchAsync($"status={statusIdOrName}");

                Console.Clear();
                Console.WriteLine($"Found {issues.Count} issues:");
                foreach (var issue in issues)
                {
                    Console.WriteLine($"{issue.Id.ToString().PadRight(6)} - {issue.Key}");
                }

                Console.ReadLine();
            }
        }
    }
}

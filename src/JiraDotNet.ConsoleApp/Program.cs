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
                var issue = await jiraClient.CreateIssueAsync(
                    new Issue
                    {
                        IssueFields = new IssueFields
                        {
                            Project = new Project
                            {
                                Id = 11000
                            },
                            IssueType = new IssueType
                            {
                                Id = 10500
                            },
                            Summary = "New Test ISSUE from JiraDotNet",
                        }
                    });

                Console.WriteLine(issue);
            }
        }
    }
}

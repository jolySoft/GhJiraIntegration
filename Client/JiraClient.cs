using GhJiraIntegration.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GhJiraIntegration.Client
{
    public class JiraClient
    {
        private HttpClient _jiraClient;

        public JiraClient()
        {
            _jiraClient = new HttpClient();

        }

        public async Task CreateTicket(string summary)
        {
            var jiraRequest = new JiraIssueRequest()
            {
                fields = new Fields
                {
                    summary = summary,
                    project = new Project
                    {
                        key = "GHIN",
                    },
                    description = summary,
                    issuetype = new Issuetype
                    {
                        name = "Task",
                    }
                }
            };

            await PostToJira(jiraRequest, @"https://gibhubintegration.atlassian.net/rest/api/3/issue/");
        }

        public async Task CreateVersion(string fixVersion)
        {
            var jiraRequest = new JiraVersionRequest
            {
                Name = fixVersion,
                Description = $"This is for release: ${fixVersion}",
                ProjectId = 10000,
                ReleaseDate = DateTime.Today
            };

            await PostToJira(jiraRequest, @"https://gibhubintegration.atlassian.net/rest/api/3/version/");
        }

        private async Task PostToJira(object jiraRequest, string url)
        {
            var json = JsonConvert.SerializeObject(jiraRequest);
            //construct content to send
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var authorization = new AuthenticationHeaderValue("Basic",
                "a2h1cnJhbW1vaGFtbWVkMTk5MEBnbWFpbC5jb206MWphZGpubDhBRGtqWFM5ZTJkNGM3M0RD");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Content = content,
                Method = HttpMethod.Post,
                Headers =
                {
                    Authorization = authorization
                }
            };
            await _jiraClient.SendAsync(request);
        }
    }
}
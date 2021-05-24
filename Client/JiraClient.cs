using GhJiraIntegration.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GhJiraIntegration.Client
{
    public class JiraClient
    {
        private HttpClient _jiraClient;
        private List<string> _ticketUrls;

        public JiraClient()
        {
            _jiraClient = new HttpClient();
            _ticketUrls = new List<string>();
        }

        public async Task CreateTicket(string summary, List<string> ticketNumbers)
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
                    issuetype = new Issuetype
                    {
                        name = "Task",
                    }
                }
            };

            jiraRequest.fields.description = GetTicketUrls(ticketNumbers);

            await PostToJira(jiraRequest, @"https://gibhubintegration.atlassian.net/rest/api/2/issue/");
        }

        private string GetTicketUrls(List<string> ticketNumbers)
        {
            var urls = new StringBuilder();

            foreach (var ticketNumber in ticketNumbers)
            {
                urls.Append($"https://gibhubintegration.atlassian.net/browse/{ticketNumber}\n");
            }

            return urls.ToString();
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

        private async Task<HttpResponseMessage> PostToJira(object jiraRequest, string url)
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
            
            return await _jiraClient.SendAsync(request);
        }
    }
}
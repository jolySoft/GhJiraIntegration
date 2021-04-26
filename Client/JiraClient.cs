using GhJiraIntegration.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GhJiraIntegration.Client
{
    public class JiraClient
    {
        public async Task CreateTicket(string summary)
        {
            var newJiraClient = new HttpClient();
            var jiraRequest = new JiraRequest()
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

            var json = JsonConvert.SerializeObject(jiraRequest);
            //construct content to send
            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var authorization = new AuthenticationHeaderValue("Basic", "a2h1cnJhbW1vaGFtbWVkMTk5MEBnbWFpbC5jb206MWphZGpubDhBRGtqWFM5ZTJkNGM3M0RD");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(@"https://gibhubintegration.atlassian.net/rest/api/2/issue/"),
                Content = content,
                Method = HttpMethod.Post,
                Headers =
                {
                    Authorization = authorization
                }
        };
            await newJiraClient.SendAsync(request);
        }
    }
}
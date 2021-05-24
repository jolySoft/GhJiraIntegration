using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GhJiraIntegration.Client
{
    public class GithubClient
    {
        private HttpClient _githubClient;

        public GithubClient()
        {
            _githubClient = new HttpClient();
            _githubClient.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.28.0");
        }

        public async Task<HttpResponseMessage> GetFromGithub( string url)
        {
            //var request = new HttpRequestMessage
            //{
            //    RequestUri = new Uri(url),
            //    Method = HttpMethod.Get,
            //    Headers =
            //    {
            //        {"User-Agent", "PostmanRuntime/7.28.0" }
            //    }
            //};
            return await _githubClient.GetAsync(url);
        }
    }
}
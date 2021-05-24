using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GhJiraIntegration.Client
{
    public class GithubClient
    {
        private HttpClient _githubClient;

        public GithubClient()
        {
            _githubClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetFromGithub( string url)
        {
            
            //construct content to send
            
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
               
            };

            return await _githubClient.SendAsync(request);
        }
    }
}
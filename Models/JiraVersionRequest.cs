using System;

namespace GhJiraIntegration.Models
{
    public class JiraVersionRequest
    {
        public string name { get; set; }
        public string description { get; set; }
        public string releaseDate { get; set; }
        public int projectId { get; set; }
    }
}
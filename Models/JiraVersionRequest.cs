using System;

namespace GhJiraIntegration.Models
{
    public class JiraVersionRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ProjectId { get; set; }
    }
}
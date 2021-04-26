using System;

namespace GhJiraIntegration.Models
{
    public class GitWebHookRequest
    {
        public string Ref_Type { get; set; }
        public string Ref { get; set; }

        public bool IsReleaseBranch()
        {
            return Ref.Contains("release", StringComparison.InvariantCultureIgnoreCase);
        }


    }
}
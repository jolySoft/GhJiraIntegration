using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GhJiraIntegration.Models
{

     public class JiraIssueRequest
     {
         public Fields fields { get; set; }
     }

     public class Fields
     {
         public Project project { get; set; }
         public string summary { get; set; }
         public string description { get; set; }
         public Issuetype issuetype { get; set; }
     }
}

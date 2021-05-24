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

     public class Project
     {
         public string key { get; set; } //project key
     }

     public class Issuetype
     {
         public string name { get; set; }  //Can be type of issue e.g. bug, story, task.
     }
}

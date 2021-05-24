﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using GhJiraIntegration.Client;
using GhJiraIntegration.Models;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json;

namespace GhJiraIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraHookController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GitWebHookRequest request)
        {
            if (request.Ref_Type != "branch") return BadRequest("Not a branch payload");

            if (request.IsReleaseBranch())
            {
                var client = new JiraClient();

                var githubClient = new GithubClient();

                var githubResponse = await githubClient.GetFromGithub("https://api.github.com/repos/jolySoft/GhJiraIntegration--ParamCompare/compare/main...production");
                var jsonResponse = JsonConvert.DeserializeObject<GitWebhookBranchCompareResponse>( githubResponse.ToString());
                //curl - X GET https://api.github.com/repos/jolySoft/GhJiraIntegration--ParamCompare/compare/main...production

                var response = new GitWebhookBranchCompareResponse
                {
                    ahead_by = 2,
                    commits = new Commit2[] { new Commit2 { commit = new Commit3 { message = "GHIN-6 Create version before creating ticket" } } }
                };
                
                var ticketNumberRegex = new Regex(@"GHIN-\d+");
                var ticketList = new HashSet<string>();
                if(response.ahead_by > 0)
                {
                    await client.CreateVersion(request.Ref);
                    foreach(var commit in response.commits)
                    {
                        if (commit.commit.message.Contains("GHIN-"))
                        {
                            var ticketNumber = commit.commit.message;
                            ticketList.Add(ticketNumberRegex.Match(ticketNumber).ToString());
                        }    
                    }
                }
                await client.CreateTicket(request.Ref, ticketList.ToList());

                return Ok("Created ticket");
            }

            return Ok("Nothing to do");
        }

        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("we're good");
            return Ok("We're good");
        }
    }
}

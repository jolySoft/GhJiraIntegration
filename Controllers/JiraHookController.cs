using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using GhJiraIntegration.Client;
using GhJiraIntegration.Models;

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
                await client.CreateTicket(request.Ref);

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

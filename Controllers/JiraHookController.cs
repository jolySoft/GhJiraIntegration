using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GhJiraIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraHookController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(object payload)
        {
            Console.WriteLine("we're logging");
            return Ok("Works");
        }

        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("we're good");
            return Ok("We're good");
        }
    }
}

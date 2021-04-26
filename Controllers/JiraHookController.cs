using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GhJiraIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraHookController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(object payload)
        {
            Debug.Write(payload);
            return Ok("Works");
        }

        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("We're good");
        }
    }
}

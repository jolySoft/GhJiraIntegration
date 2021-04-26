using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GhJiraIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraHookController : ControllerBase
    {
        public IActionResult Create()
        {
            return Ok("Works");
        }
    }
}

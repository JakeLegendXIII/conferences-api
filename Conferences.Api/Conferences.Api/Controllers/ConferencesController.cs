using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conferences.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetConferences()
        {
            return Ok();
        }
    }
}
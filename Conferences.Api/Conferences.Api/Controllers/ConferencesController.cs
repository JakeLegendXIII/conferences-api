using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conferences.Api.Domain;
using Conferences.Api.Mapper;
using Conferences.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conferences.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private IMapConferences _conferenceMapper;

        public ConferencesController(IMapConferences conferenceMapper) => _conferenceMapper = conferenceMapper;

        [HttpGet("")]
        public async Task<IActionResult> GetConferences([FromQuery] string topic)
        {
            try
            {
                ConferencesResponse response = await _conferenceMapper.GetAllConferences(topic);
                return Ok(response);
            }
            catch(Exception ex)
            {
                // do something here like log the error
                return StatusCode(500);
            }                                                     
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conferences.Api.Domain;
using Conferences.Api.Mapper;
using Conferences.Api.Models;
using Conferences.Api.Helpers;
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
            catch (Exception ex)
            {
                // do something here like log the error
                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}", Name = "conferences#getaconference")]
        public async Task<IActionResult> GetAConference(int id)
        {
            try
            {
                ConferenceGetResponse response = await _conferenceMapper.GetConferenceById(id);
                return this.Maybe(response);
            }
            catch (Exception ex)
            {
                // do something here like log the error
                return StatusCode(500);
            }           
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddConference([FromBody] ConferenceCreate conferenceToAdd)
        {
            try
            {
                ConferenceGetResponse response = await _conferenceMapper.Add(conferenceToAdd);
                return CreatedAtRoute("conferences#getaconference", new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                // do something here like log the error
                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveConference(int id)
        {
            try
            {
                await _conferenceMapper.Remove(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // do something here like log the error
                return StatusCode(500);
            }
        }
    }
}
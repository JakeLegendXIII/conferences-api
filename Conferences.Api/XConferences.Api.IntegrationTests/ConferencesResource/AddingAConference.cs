using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XConferences.Api.IntegrationTests.ConferencesResource
{
    public class AddingAConference : HttpBase
    {
        [Fact]
        public async Task AddingANewConferenceSuccessfully()
        {
            // Given I have a new Conference and an empty database
            var conferenceToAdd = new conferenceCreate()
            {
                name = "Code Conf",
                state = "HI",
                city = "Honolulu",
                startDate = DateTime.Now.AddDays(20),
                endDate = DateTime.Now.AddDays(24),
                attending = true,
                speaking = false,
                focusTopic = "APIs"
            };
            // When I Post that Conference to the resource
            var response = await Client.PostAsJsonAsync("/api/v1/conferences", conferenceToAdd);
            // Then I should get a 201 status code
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            //  and I should have a location header
            var location = response.Headers.Location.ToString();
            Assert.Equal("http://localhost/api/v1/conferences/1".ToLower(), location.ToLower());
            // and I should have an entity of the new employee
            var entity = await response.Content.ReadAsAsync<conferencesDetails>();
            Assert.Equal(1, entity.id);
            Assert.Equal("Code Conf", entity.name);
            Assert.Equal("HI", entity.state);
            Assert.Equal("Honolulu", entity.city);
            Assert.Equal("APIs", entity.focusTopic);
        }

        [Fact]
        public async Task AddingANewConferenceValidation()
        {
            // Given I have a new Conference and an empty database with no name and topic PHP...
            var conferenceToAdd = new conferenceCreate()
            {
                state = "HI",
                city = "Honolulu",
                startDate = DateTime.Now.AddDays(20),
                endDate = DateTime.Now.AddDays(24),
                attending = true,
                speaking = false,
                focusTopic = "PHP"
            };
            // When I Post that Conference to the resource
            var response = await Client.PostAsJsonAsync("/api/v1/conferences", conferenceToAdd);
            // Then I should get a 400 status code
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }


    public class conferenceCreate
    {
        public string name { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool attending { get; set; }
        public bool speaking { get; set; }
        public string focusTopic { get; set; }
    }

}

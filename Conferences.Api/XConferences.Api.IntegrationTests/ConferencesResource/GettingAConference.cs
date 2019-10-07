using Conferences.Api.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XConferences.Api.IntegrationTests.ConferencesResource
{
    public class GettingAConference : HttpBase
    {                
        [Fact]
        public async Task GetsAnOk()
        {
            SetupMockData();
            var response = await GetResponseFor(1);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetsAConference()
        {
            // Given the database has a conference
            SetupMockData();
            //when I ask for the conference
            var response = await GetResponseFor(1);
            var content = await response.Content.ReadAsAsync<conferencesDetails>();
            // then it looks like this
            Assert.Equal(1, content.id);
            Assert.Equal("Test Conf", content.name);
            Assert.Equal("TX", content.state);
            Assert.Equal("Austin", content.city);
            Assert.Equal("APIs", content.focusTopic);
        }

        [Fact]
        public async Task GetsFourOhFourForMissingConference()
        {
            // Given I have an empty database
            // When I get employee 1
            var response = await GetResponseFor(1);
            // Then it should not be found 404
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        private async void SetupMockData()
        {
            var topic1 = new Topic
            {
                Id = 1,
                Name = "APIs"
            };
            var conference1 = new Conference
            {
                Id = 1,
                Name = "Test Conf",
                State = "TX",
                City = "Austin",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(4),
                Attending = true,
                Speaking = true,
                FocusTopic = topic1
            };
            Context.Topics.Add(topic1);
            Context.Conferences.Add(conference1);
            await Context.SaveChangesAsync();
        }

        public async Task<HttpResponseMessage> GetResponseFor(int conferenceId)
        {
            return await Client.GetAsync($"api/v1/conferences/{conferenceId}");
        }
    }

    public class conferencesDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string focusTopic { get; set; }
    }
}

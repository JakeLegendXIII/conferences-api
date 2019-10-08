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
    public class UpdatingAConference : HttpBase
    {
        [Fact]
        public async Task UpdateConferenceAttendanceToFalse()
        {
            /* using Mini-Put pattern */

            // Given I have a conference I am attending
            SetupMockData();
            var jsonString = "false";
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            // When I can no longer attend
            var response = await Client.PutAsync($"/api/v1/conferences/{1}/attending", httpContent);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            // Then the data should be updated accordingly

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
    }
}

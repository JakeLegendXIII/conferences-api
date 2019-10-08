using Conferences.Api.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XConferences.Api.IntegrationTests.ConferencesResource
{
    public class RemovingAConference : HttpBase
    {
        [Fact]
        public async Task CanDeleteAConference()
        {
            /* Rarely in the real world do we actually delete generally it's a status change
             * for this api though we will be doing a true delete */

            // Given I have a conference
            SetupMockData();
            // When I delete them
            var deleteResposne = await Client.DeleteAsync("/api/v1/conferences/1");
            // Then they should be removed from the collection
            Assert.Equal(HttpStatusCode.NoContent, deleteResposne.StatusCode);
            var getResponse = await Client.GetAsync("/api/v1/conference/1");
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
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

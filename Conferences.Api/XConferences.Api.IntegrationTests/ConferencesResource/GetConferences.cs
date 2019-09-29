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
    public class GetConferences : HttpBase
    {
        [Fact]
        public async Task GetsAnOk()
        {
            var response = await Client.GetAsync("api/v1/conferences");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetsConferences()
        {          
            SetupMockData();

            var response = await Client.GetAsync("api/v1/conferences");
            var conferences = await response.Content.ReadAsAsync<conferencesResponse>();

            Assert.Equal(3, conferences.count);
            Assert.Equal("Test Conf", conferences._embedded[0].name);
            Assert.Equal("S Conf", conferences._embedded[1].name);
            Assert.Equal("Code Conf", conferences._embedded[2].name);
            // feel free to validate any other fields as well
        }

        [Fact]
        public async Task GetsFilteredConferences()
        {
            SetupMockData();

            var response = await Client.GetAsync("api/v1/conferences?topic=APIs");
            var conferences = await response.Content.ReadAsAsync<conferencesResponse>();

            Assert.Equal(2, conferences.count);
            Assert.Equal("Test Conf", conferences._embedded[0].name);
            Assert.Equal("S Conf", conferences._embedded[1].name);
            Assert.Equal("APIs", conferences.topicFilter);
        }

        private async void SetupMockData()
        {
            var topic1 = new Topic
            {
                Id = 1,
                Name = "APIs"
            };
            var topic2 = new Topic
            {
                Id = 2,
                Name = "Angular"
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
            var conference2 = new Conference
            {
                Id = 2,
                Name = "S Conf",
                State = "TX",
                City = "Austin",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(4),
                Attending = true,
                Speaking = false,
                FocusTopic = topic1
            };
            var conference3 = new Conference
            {
                Id = 3,
                Name = "Code Conf",
                State = "GA",
                City = "Atlanta",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(3),
                Attending = false,
                Speaking = false,
                FocusTopic = topic2
            };
            Context.Topics.Add(topic1);
            Context.Topics.Add(topic2);
            Context.Conferences.Add(conference1);
            Context.Conferences.Add(conference2);
            Context.Conferences.Add(conference3);
            await Context.SaveChangesAsync();
        }
    }


    public class conferencesResponse
    {
        public conferencesSummaryItem[] _embedded { get; set; }
        public object topicFilter { get; set; }
        public int count { get; set; }
    }

    public class conferencesSummaryItem
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

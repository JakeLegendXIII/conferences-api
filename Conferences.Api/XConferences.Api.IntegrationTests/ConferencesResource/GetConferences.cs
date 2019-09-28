using System;
using System.Collections.Generic;
using System.Net;
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
    }
}

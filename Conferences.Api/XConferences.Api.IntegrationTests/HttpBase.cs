using Conferences.Api;
using Conferences.Api.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace XConferences.Api.IntegrationTests
{
    public class HttpBase
    {
        protected readonly HttpClient Client;
        protected readonly ConferenceDataContext Context;

        public HttpBase()
        {
            var builder = new WebHostBuilder()
                .ConfigureAppConfiguration((hosting, config) =>
                {

                })
                .UseEnvironment("testing")
                .UseStartup<Startup>();

            var server = new TestServer(builder);
            Client = server.CreateClient();
            Context = server.Host.Services.GetService(typeof(ConferenceDataContext)) as ConferenceDataContext;
        }
    }
}

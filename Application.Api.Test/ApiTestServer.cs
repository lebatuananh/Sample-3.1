using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace Application.Api.Test
{
    public class ApiTestServer
    {
        public TestServer CreateServer()
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .Build();

            var hostBuilder = new WebHostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddConfiguration(configuration);
                }).UseStartup<ApiTestStartup>();

            var testServer = new TestServer(hostBuilder);

            return testServer;
        }

    }
}

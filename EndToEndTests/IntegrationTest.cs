using HouseProject.Api;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndTests
{
    public class IntegrationTest
    {
        protected readonly TestServer _testServer;
        protected readonly HttpClient _httpClient;

        public IntegrationTest()
        {
            //Arrange
            var projectDir = Helper.GetProjectPath("", typeof(Startup).GetTypeInfo().Assembly);
            _testServer = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Startup>());
            _httpClient = _testServer.CreateClient();
        }

    }
}

using Application.Core.Paginations;
using Application.Document.Query.GetDocuments;
using FluentAssertions;
using HouseProject.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EndToEndTests.Controllers
{
    public class DocumentsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _httpClient;
        public DocumentsControllerTests()
        {
            //Arrange
            var projectDir = Helper.GetProjectPath("", typeof(Startup).GetTypeInfo().Assembly);
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Startup>());
            _httpClient = _server.CreateClient();
        }

        [Fact]
        public async Task GetDocumentsAsync_GivenValidRequest_ShouldReturnNotEmptyCollection()
        {
            //Act
            var response = await _httpClient.GetAsync(@"/api/Documents");
            var content = await response.Content.ReadAsStringAsync();
            var pagedResponse = JsonConvert.DeserializeObject<PaginationResult<IEnumerable<GetDocumentDto>>>(content);

            //Assert
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
            pagedResponse.Value.Should().NotBeNull();

        }

    }
}

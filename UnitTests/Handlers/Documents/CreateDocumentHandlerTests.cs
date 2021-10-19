using Application.Documents.Command.CreateDocument;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Handlers.Documents
{
    public class CreateDocumentHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private string userId = "031eca6d-8300-4cb0-b0c8-3d7eecf9b718";
        private Mock<IDocumentRepository> _documentRepositoryMock;
        private CreateDocumentHandler _createDocumentHandler;
        public CreateDocumentHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _documentRepositoryMock = new Mock<IDocumentRepository>();
            _createDocumentHandler = new CreateDocumentHandler(_documentRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateDocumentHandler_GivenValidRequest_ShouldAddDocument()
        {
            //Arrange

            var createDocumentDto = new CreateDocumentDto()
            {
                Name = "test name",
                ReceivedAt = new DateTime(2021, 10, 6),
                Cost = "10",
                Description = "test description",
            };

            var document = new Document()
            {
                Name = createDocumentDto.Name,
                ReceivedAt = createDocumentDto.ReceivedAt,
                Cost = decimal.Parse(createDocumentDto.Cost),
                Description = createDocumentDto.Description
            };

            _mapperMock.Setup(x => x.Map<Document>(createDocumentDto)).Returns(document);

            var request = new CreateDocumentCommand { CreateDocumentDto = createDocumentDto, UserId = userId };

            //Act -> add new post
            await _createDocumentHandler.Handle(request, CancellationToken.None);

            //Assert
            _documentRepositoryMock.Verify(x => x.AddAsync(document), Times.Once);

            document.Should().NotBeNull();
            document.Name.Length.Should().BeLessOrEqualTo(100);
            document.Name.Length.Should().BeGreaterOrEqualTo(0);
            document.Name.Should().NotBeEmpty();
            document.Cost.Value.Should().BeGreaterOrEqualTo(0);

        }

    }
}

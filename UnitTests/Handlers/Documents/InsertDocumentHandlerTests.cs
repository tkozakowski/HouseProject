using Application.Documents.Command.CreateDocument;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Handlers.Documents
{
    public class InsertDocumentHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMediator> _mediatorMock;
        private string userId = "031eca6d-8300-4cb0-b0c8-3d7eecf9b718";
        private Mock<IDocumentRepository> _documentRepositoryMock;
        private Mock<CreateDocumentHandler> _insertDocumentHandlerMock;
        public InsertDocumentHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _mediatorMock = new Mock<IMediator>();
            _documentRepositoryMock = new Mock<IDocumentRepository>();
            _insertDocumentHandlerMock = new Mock<CreateDocumentHandler>(_documentRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertDocument()
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
            var result = await _insertDocumentHandlerMock.Object.Handle(request, CancellationToken.None);

            //Assert
            _documentRepositoryMock.Verify(x => x.AddAsync(document), Times.Once);
        }

    }
}

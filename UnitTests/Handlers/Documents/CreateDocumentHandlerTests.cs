using Application.Documents.Command.CreateDocument;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Handlers.Documents
{
    public class CreateDocumentHandlerTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMediator> _mediatorMock;

        public CreateDocumentHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task CreateDocumentHandler_GivenValidRequest_ShouldAddDocument()
        {
            //Arrange
            var factory = new ConnectionFactory();

            var context = factory.CreateContextForInMemory();


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

            var createDocumentCommand = new CreateDocumentCommand { CreateDocumentDto = createDocumentDto, UserId = factory.UserId };

            CreateDocumentHandler createDocumentHandler = new(_mapperMock.Object, context, _mediatorMock.Object);

            //Act->add new post
            await createDocumentHandler.Handle(createDocumentCommand, CancellationToken.None);

            //Assert
            var documentsInMemory = await context.Documents.ToListAsync();
            Assert.Single(documentsInMemory);

            var addedDocument = documentsInMemory.Last();
            addedDocument.Should().NotBeNull();
            addedDocument.Name.Length.Should().BeLessOrEqualTo(100);
            addedDocument.Name.Length.Should().BeGreaterOrEqualTo(0);
            addedDocument.Name.Should().NotBeEmpty();
            addedDocument.Cost.Value.Should().BeGreaterOrEqualTo(0);

            //Check names
            var singleDocument = context.Documents.FirstOrDefault(x => x.Id == 1);
            Assert.Equal(singleDocument.Name, document.Name);
        }

    }
}

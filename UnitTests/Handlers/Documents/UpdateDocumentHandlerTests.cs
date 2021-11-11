using Application.Documents.Command.UpdateDocument;
using Application.Finance.Command.UpdateByDocument;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Handlers.Documents
{
    public class UpdateDocumentHandlerTests
    {
        private readonly string userId = "9aeb84c8-0d2b-4f4d-9c3d-dc4356ddda85";
        private readonly Mock<IMediator> _mediatorMock;

        public UpdateDocumentHandlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task UpdateDocumentHandler_GivenValidDocument_ShouldUpdateDocument()
        {
            //Arrange
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForInMemory();

            var existedDocument = new Document
            {
                Cost = 100,
                Description = "description",
                Name = "name",
                ReceivedAt = new DateTime(2021, 11, 11)
            };

            context.Documents.Add(existedDocument);
            await context.SaveChangesAsync();

            var updateDocumentDto = new UpdateDocumentDto
            {
                Cost = "1",
                Description = "description",
                Name = "name",
                ReceivedAt = new DateTime(2021, 11, 11)
            };

            var document = new Document
            {
                Cost = decimal.Parse(updateDocumentDto.Cost),
                Description = updateDocumentDto.Description,
                Name = updateDocumentDto.Name,
                ReceivedAt = updateDocumentDto.ReceivedAt
            };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Document>(updateDocumentDto)).Returns(document);


            var updateDocumentCommand = new UpdateDocumentCommand { Id = 1, UpdateDocumentDto = updateDocumentDto, UserId = userId };
            
            var updateDocumentHandler = new UpdateDocumentHandler(mapperMock.Object, context, _mediatorMock.Object);

            //Act
            await updateDocumentHandler.Handle(updateDocumentCommand, CancellationToken.None);

            var dbDocument = await context.Documents.FirstOrDefaultAsync(x => x.Name == "name");

            //Assert
            dbDocument.Name.Should().BeEquivalentTo(existedDocument.Name);
            dbDocument.Cost.Should().BeInRange(99, 101);

        }

        [Fact]
        public async Task UpdateDocumentHandler_GivenValidDocument_AfterSaveToDbShouldInvokeUpdateFinanceByDocumentCommand()
        {
            //Arrange
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForInMemory();

            var existedDocument = new Document
            {
                Cost = 100,
                Description = "description",
                Name = "name",
                ReceivedAt = new DateTime(2021, 11, 11)
            };

            context.Documents.Add(existedDocument);
            await context.SaveChangesAsync();

            var updateDocumentDto = new UpdateDocumentDto
            {
                Cost = "1",
                Description = "description",
                Name = "name",
                ReceivedAt = new DateTime(2021, 11, 11)
            };

            var document = new Document
            {
                Cost = decimal.Parse(updateDocumentDto.Cost),
                Description = updateDocumentDto.Description,
                Name = updateDocumentDto.Name,
                ReceivedAt = updateDocumentDto.ReceivedAt
            };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Document>(updateDocumentDto)).Returns(document);


            var updateDocumentCommand = new UpdateDocumentCommand { Id = 1, UpdateDocumentDto = updateDocumentDto, UserId = userId };

            var updateDocumentHandler = new UpdateDocumentHandler(mapperMock.Object, context, _mediatorMock.Object);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<UpdateFinanceByDocumentCommand>(), It.IsAny<CancellationToken>()));

            //Act
            await updateDocumentHandler.Handle(updateDocumentCommand, CancellationToken.None);

            //Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<UpdateFinanceByDocumentCommand>(), It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}

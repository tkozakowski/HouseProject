using Application.Command.Documents;
using Application.Dto;
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
    public class InsertDocumentTests
    {

        [Fact]
        public async Task insert_document_should_create_new_document()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var mediatorMock = new Mock<IMediator>();
            var userId = "031eca6d-8300-4cb0-b0c8-3d7eecf9b718";

            var documentDto = new CreateDocumentDto()
            {
                Name = "test name",
                ReceivedAt = new DateTime(2021, 10, 6),
                Cost = "10",
                Description = "test description",
            };

            var document = mapperMock.Setup(x => x.Map<Document>(documentDto))
                .Returns(new Document
                {
                    Name = documentDto.Name,
                    ReceivedAt = documentDto.ReceivedAt,
                    Cost = decimal.Parse(documentDto.Cost),
                    Description = documentDto.Description,
                });

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertDocumentCommand>(), It.IsAny<CancellationToken>()));

            //Act -> add new post
            await mediatorMock.Object.Send(new InsertDocumentCommand(documentDto, userId));

            //Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<InsertDocumentCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task insert_document_should_invoke_add_async_document_in_repository()
        {
            //Arrange
            var mapperMock = new Mock<IMapper>();
            var mediatorMock = new Mock<IMediator>();
            var userId = "031eca6d-8300-4cb0-b0c8-3d7eecf9b718";
            var documentRepositoryMock = new Mock<IDocumentRepository>();

            var createDocumentDto = new CreateDocumentDto()
            {
                Name = "test name",
                ReceivedAt = new DateTime(2021, 10, 6),
                Cost = "10",
                Description = "test description",
            };

            var document = mapperMock.Setup(x => x.Map<Document>(createDocumentDto)).Returns(new Document 
            {
                Name = createDocumentDto.Name,
                ReceivedAt = createDocumentDto.ReceivedAt,
                Cost = decimal.Parse(createDocumentDto.Cost),
                Description = createDocumentDto.Description
            });

            //Act 
            await mediatorMock.Object.Send(new InsertDocumentCommand(createDocumentDto, userId));

            //Assert
            documentRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Document>()), Times.Once);
        }
    }
}

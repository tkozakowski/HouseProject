﻿using Application.Documents.Command.CreateDocument;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
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
        private string userId = "031eca6d-8300-4cb0-b0c8-3d7eecf9b718";

        public CreateDocumentHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
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

            var createDocumentCommand = new CreateDocumentCommand { CreateDocumentDto = createDocumentDto, UserId = userId };

            CreateDocumentHandler createDocumentHandler = new(_mapperMock.Object, context);

            //Act->add new post
            await createDocumentHandler.Handle(createDocumentCommand, CancellationToken.None);

            //Assert
            var documentsInMemory = await context.Documents.ToListAsync();
            documentsInMemory.Count.Should().BeInRange(1, 1);

            var addedDocument = documentsInMemory.Last();
            addedDocument.Should().NotBeNull();
            addedDocument.Name.Length.Should().BeLessOrEqualTo(100);
            addedDocument.Name.Length.Should().BeGreaterOrEqualTo(0);
            addedDocument.Name.Should().NotBeEmpty();
            addedDocument.Cost.Value.Should().BeGreaterOrEqualTo(0);

        }

    }
}

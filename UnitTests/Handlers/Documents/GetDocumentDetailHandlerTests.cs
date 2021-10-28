using Application.Core;
using Application.Document.Query.GetDocuments;
using Application.Documents.Query.Details;
using Application.Documents.Query.GetDocumentDetails;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.Handlers.Helpers;
using Xunit;

namespace UnitTests.Handlers.Documents
{
    public class GetDocumentDetailHandlerTests
    {

        private readonly Mock<IMapper> _mapperMock;

        public GetDocumentDetailHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldReturnDocument()
        {

            //Arrange
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForInMemory();

            var document = new Document
            {
                Id = 1,
                Name = "test name",
                ReceivedAt = new DateTime(2021, 10, 6),
                Cost = 10,
                Description = "test description",
            };

            var getDocumentDto = new DocumentDetailsDto
            {
                Id = document.Id,
                Name = document.Name,
                ReceivedAt = document.ReceivedAt,
                Cost = document.Cost.ToString(),
                Description = document.Description
            };

            context.Documents.Add(document);
            await context.SaveChangesAsync();

            var addedDocument = await context.Documents.FirstOrDefaultAsync(x => x.Id == 1);
            _mapperMock.Setup(x => x.Map<DocumentDetailsDto>(addedDocument)).Returns(getDocumentDto);

            var getDocumentDetailHandler = new GetDocumentDetailHandler(_mapperMock.Object, context);

            var responseDocument = Result<DocumentDetailsDto>.Success(getDocumentDto);

            var getDocumentDetailQuery = new GetDocumentDetailQuery(1);

            //Act
            var handleResult = await getDocumentDetailHandler.Handle(getDocumentDetailQuery, CancellationToken.None);

            //Assert
            handleResult.Should().BeOfType<Result<DocumentDetailsDto>>();

            handleResult.Should().BeEquivalentTo(responseDocument);
        }

    }
}

using Application.Document.Query.GetDocuments;
using Application.Documents.Query.Details;
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
    //public class GetDocumentDetailHandlerTests
    //{

    //    private readonly Mock<IMapper> _mapperMock;
    //    private readonly Mock<IDocumentRepository> _documentRepositoryMock;
    //    private readonly GetDocumentDetailHandler _getDocumentDetailHandler;
    //    private readonly GetDocumentDetailQuery _request;

    //    public GetDocumentDetailHandlerTests()
    //    {
    //        _mapperMock = new Mock<IMapper>();
    //        _documentRepositoryMock = new Mock<IDocumentRepository>();
    //        _getDocumentDetailHandler = new GetDocumentDetailHandler(_mapperMock.Object, _documentRepositoryMock.Object);
    //        _request = new GetDocumentDetailQuery(1);
    //    }

    //    [Fact]
    //    public async Task Handle_GivenValidRequest_ShouldReturnDocument()
    //    {
    //        //Arrange
    //        var document = new Document
    //        {
    //            Name = "test name",
    //            ReceivedAt = new DateTime(2021, 10, 6),
    //            Cost = 10,
    //            Description = "test description",
    //        };

    //        var documentDto = new GetDocumentDto
    //        {
    //            Name = document.Name,
    //            ReceivedAt = document.ReceivedAt,
    //            Cost = document.Cost.ToString(),
    //            Description = document.Description
    //        };

    //        _documentRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(document);

    //        _mapperMock.Setup(x => x.Map<GetDocumentDto>(document)).Returns(documentDto);


    //        //Act
    //        var result = await _getDocumentDetailHandler.Handle(_request, CancellationToken.None);

    //        //Assert
    //        _documentRepositoryMock.Verify(x => x.GetByIdAsync(1), Times.Once);
    //        documentDto.Should().NotBeNull();
    //        documentDto.Name.Should().NotBeNull();
    //        documentDto.Name.Should().BeEquivalentTo(document.Name);
    //        documentDto.Description.Should().NotBeNull();
    //        documentDto.Description.Should().BeEquivalentTo(document.Description);
    //    }

    //}
}

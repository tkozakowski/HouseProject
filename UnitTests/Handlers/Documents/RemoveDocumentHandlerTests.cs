using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Documents.Command.RemoveDocument;
using Xunit;
using System.Threading;
using Domain.Entities;

namespace UnitTests.Handlers.Documents
{
    //public class RemoveDocumentHandlerTests
    //{
    //    private readonly Mock<IDocumentRepository> _documentRepositoryMock;
    //    private readonly RemoveDocumentHandler _removeDocumentHandler;
    //    private readonly int id;

    //    public RemoveDocumentHandlerTests()
    //    {
    //        _documentRepositoryMock = new Mock<IDocumentRepository>();
    //        _removeDocumentHandler = new RemoveDocumentHandler(_documentRepositoryMock.Object);
    //    }

    //    [Fact]
    //    public async Task RemoveDocumentHandler_GivenId_RemoveDocument()
    //    {
    //        //Arrange
    //        var document = new Document
    //        {
    //            Id = 2,
    //            Cost = 5.0M,
    //            Description = "description",
    //            Name = "name",
    //            CreatedAt = new DateTime(2021, 10, 16)
    //        };

    //        //Act
    //        var result = await _removeDocumentHandler.Handle(new RemoveDocumentCommand { Id = id }, CancellationToken.None);

    //        //Assert
    //        _documentRepositoryMock.Verify(x => x.RemoveAsync(id), Times.Once);
    //    }


    //}
}

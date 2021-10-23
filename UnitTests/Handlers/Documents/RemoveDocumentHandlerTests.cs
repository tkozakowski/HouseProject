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
using UnitTests.Handlers.Helpers;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace UnitTests.Handlers.Documents
{
    public class RemoveDocumentHandlerTests
    {

        [Fact]
        public async Task RemoveDocumentHandler_GivenId_RemoveDocument()
        {

            var factory = new ConnectionFactory();
            var context = factory.CreateContextForInMemory();

            //Arrange
            context.Documents.Add(new Document { Id = 1, Cost = 1M, Description = "desc1", Name = "name1" });
            context.Documents.Add(new Document { Id = 2, Cost = 2M, Description = "desc2", Name = "name2" });
            await context.SaveChangesAsync();

            var removeDocumentHandler = new RemoveDocumentHandler(context);

            //Act
            var addedDocument2 = await context.Documents.FirstOrDefaultAsync(x => x.Id == 2);
            var allDocuments = (await context.Documents.ToListAsync()).Count();

            await removeDocumentHandler.Handle(new RemoveDocumentCommand { Id = 2 }, CancellationToken.None);

            var allDocumentsAfterRemovedSecond = (await context.Documents.ToListAsync()).Count();
            var addedDocument2Check = await context.Documents.FirstOrDefaultAsync(x => x.Id == 2);

            //Assert
            allDocuments.Should().BeGreaterThan(allDocumentsAfterRemovedSecond);
            allDocuments.Should().Equals(allDocumentsAfterRemovedSecond + 1);
            addedDocument2Check.Should().BeNull();
        }


    }
}

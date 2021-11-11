using System.Linq;
using System.Threading.Tasks;
using Application.Documents.Command.RemoveDocument;
using Xunit;
using System.Threading;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace UnitTests.Handlers.Documents
{
    public class RemoveDocumentHandlerTests
    {

        [Fact]
        public async Task Handler_RequestToRemoveByGivenId_RemoveDocument()
        {

            var factory = new ConnectionFactory();
            var context = factory.CreateContextForInMemory();

            //Arrange
            context.Documents.Add(new Document { Cost = 1M, Description = "desc1", Name = "name1" });
            context.Documents.Add(new Document { Cost = 2M, Description = "desc2", Name = "name2" });
            context.Finances.Add(new Finance { ProjectsCost = 1, PreparationsCost = 1, ExecutionsCost = 1 });
            await context.SaveChangesAsync();

            var removeDocumentHandler = new RemoveDocumentHandler(context);

            //Act
            var addedDocument2 = await context.Documents.FirstOrDefaultAsync(x => x.Description == "desc2");
            var allDocuments = (await context.Documents.ToListAsync()).Count();

            await removeDocumentHandler.Handle(new RemoveDocumentCommand { Id = addedDocument2.Id }, CancellationToken.None);

            var allDocumentsAfterRemovedSecond = (await context.Documents.ToListAsync()).Count();
            var addedDocument2Check = await context.Documents.FirstOrDefaultAsync(x => x.Description == "desc2");

            //Assert
            allDocuments.Should().BeGreaterThan(allDocumentsAfterRemovedSecond);
            allDocuments.Should().Equals(allDocumentsAfterRemovedSecond + 1);
            addedDocument2Check.Should().BeNull();
        }


    }
}

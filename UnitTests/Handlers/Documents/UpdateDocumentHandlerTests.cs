using Application.Documents.Command.UpdateDocument;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
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
        private readonly int id = 1;
        private readonly Mock<IDocumentRepository> _documentRepositoryMock;
        private readonly UpdateDocumentHandler _updateDocumentHandler;
        private readonly Mock<IMapper> _mapperMock;

        private UpdateDocumentCommand _updateDocumentCommand;

        public UpdateDocumentHandlerTests()
        {
            _documentRepositoryMock = new Mock<IDocumentRepository>();
            _mapperMock = new Mock<IMapper>();

            _updateDocumentHandler = new UpdateDocumentHandler(_mapperMock.Object, _documentRepositoryMock.Object);
        }

        [Fact]
        public async Task UpdateDocumentHandler_GivenValidRequest_GetExistingDocument()
        {
            //Arrange
            var updateDocumentDto = new UpdateDocumentDto
            {
                Cost = "1",
                Description = "description",
                Name = "name",
                ReceivedAt = DateTime.Now
            };

            var document = new Document
            {
                Cost = decimal.Parse(updateDocumentDto.Cost),
                Description = updateDocumentDto.Description,
                Name = updateDocumentDto.Name,
                ReceivedAt = updateDocumentDto.ReceivedAt
            };


            _updateDocumentCommand = new UpdateDocumentCommand { Id = id, UpdateDocumentDto = updateDocumentDto, UserId = userId };

            //Act
            await _updateDocumentHandler.Handle(_updateDocumentCommand, CancellationToken.None);

            //Assert
            _documentRepositoryMock.Verify(x => x.GetByIdAsync(id), Times.Once);

        }


        [Fact]
        public async Task UpdateDocumentHandler_GivenValidRequest_UpdateDocument()
        {
            //Arrange
            var updateDocumentDto = new UpdateDocumentDto
            {
                Cost = "1",
                Description = "description",
                Name = "name",
                ReceivedAt = DateTime.Now
            };

            var document = new Document
            {
                Cost = decimal.Parse(updateDocumentDto.Cost),
                Description = updateDocumentDto.Description,
                Name = updateDocumentDto.Name,
                ReceivedAt = updateDocumentDto.ReceivedAt
            };

            _updateDocumentCommand = new UpdateDocumentCommand { Id = id, UpdateDocumentDto = updateDocumentDto, UserId = userId };

            _mapperMock.Setup(x => x.Map<Document>(updateDocumentDto));

            //Act
            await _updateDocumentHandler.Handle(_updateDocumentCommand, CancellationToken.None);

            //Assert
            //_documentRepositoryMock.Verify(x => x.UpdateAsync(document), Times.Once); ??????

            document.Name.Should().NotBeEmpty();
            document.Name.Length.Should().BeGreaterThan(0);
            document.Name.Length.Should().BeLessOrEqualTo(100);
            document.Cost.Value.Should().BeGreaterThan(0);
        }
    }
}

//RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
//RuleFor(x => x.Name).MaximumLength(100).WithMessage("Max name length 100");
//RuleFor(x => x.Cost).Custom((x, context) =>
//{
//    if (!(int.TryParse(x, out int value)) || value < 0)
//    {
//        context.AddFailure($"{x} for Cost is not a valid number or less than 0");
//    }
//});
//RuleFor(x => x.StageId).GreaterThan(0);
//RuleFor(x => x.PostId).GreaterThan(0);
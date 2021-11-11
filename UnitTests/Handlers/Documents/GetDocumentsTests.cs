using Application.Core.Paginations;
using Application.Core.Sortings;
using Application.Document.Query.GetDocuments;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Handlers.Documents
{
    public class GetDocumentsTests
    {
        private readonly Mock<ILogger<GetDocumentListHandler>> _loggerMock;
        private readonly PaginationFilter _validPaginationFilter;
        private readonly SortingFilter _validSortingFilter;
        private readonly string filterBy = "id";
        private readonly GetDocumentListQuery _getDocumentListQuery;

        public GetDocumentsTests()
        {
            _loggerMock = new Mock<ILogger<GetDocumentListHandler>>();
            _validPaginationFilter = new PaginationFilter();
            _validSortingFilter = new SortingFilter();
            _getDocumentListQuery = new GetDocumentListQuery(_validPaginationFilter, _validSortingFilter, this.filterBy);
        }

        [Fact]
        public async Task GetDocumentListHandler_GivenValidQuery_ShouldReturnListOfDocuments()
        {
            //Arrange
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForInMemory();

            var existedDocument = new List<Document>()
            {
                new Document
                {
                    Cost = 1,
                    Description = "description1",
                    Name = "name1",
                    ReceivedAt = new DateTime(2021, 11, 11)
                },
                new Document
                {
                    Cost = 2,
                    Description = "description2",
                    Name = "name2",
                    ReceivedAt = new DateTime(2021, 11, 11)
                },
                new Document
                {
                    Cost = 3,
                    Description = "description3",
                    Name = "name3",
                    ReceivedAt = new DateTime(2021, 11, 11)
                },
            };

            context.Documents.AddRange(existedDocument);
            await context.SaveChangesAsync();


            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.ConfigurationProvider)
                .Returns(() => new MapperConfiguration(cfg => { cfg.CreateMap<Document, GetDocumentDto>(); }));


            var getDocumentListHandler = new GetDocumentListHandler(context, mapperMock.Object, _loggerMock.Object);

            var pageNumber = _getDocumentListQuery.validPaginationFilter.PageNumber;
            var pageSize = _getDocumentListQuery.validPaginationFilter.PageSize;
            var sortField = _getDocumentListQuery.validSortingFilter.SortField;
            var ascending = _getDocumentListQuery.validSortingFilter.Ascending;
            var filterBy = _getDocumentListQuery.filterBy;

            //Act
            PaginationResult<IEnumerable<GetDocumentDto>> result = await getDocumentListHandler.Handle(_getDocumentListQuery, CancellationToken.None);

            var documents = await context.Documents.ToListAsync();
            //Assert
            result.Value.Should().NotBeEmpty().And.HaveCount(3);
        }

    }
}

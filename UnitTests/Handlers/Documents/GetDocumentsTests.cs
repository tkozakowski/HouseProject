using Application.Core.Paginations;
using Application.Core.Sortings;
using Application.Document.Query.GetDocuments;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
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
    public class GetDocumentsTests
    {
        private readonly Mock<IDocumentRepository> _documentRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<GetDocumentListHandler>> _loggerMock;
        private readonly GetDocumentListHandler _getDocumentListHandler;
        private readonly PaginationFilter _validPaginationFilter;
        private readonly SortingFilter _validSortingFilter;
        private readonly string filterBy = "id";
        private readonly GetDocumentListQuery _getDocumentListQuery;

        public GetDocumentsTests()
        {
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<GetDocumentListHandler>>();
            _documentRepositoryMock = new Mock<IDocumentRepository>();
            _getDocumentListHandler = new GetDocumentListHandler(_documentRepositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
            _validPaginationFilter = new PaginationFilter();
            _validSortingFilter = new SortingFilter();
            _getDocumentListQuery = new GetDocumentListQuery(_validPaginationFilter, _validSortingFilter, this.filterBy);
        }

        [Fact]
        public async Task GetDocumentListHandler_GivenValidQuery_ShouldReturnListOfDocuments()
        {
            //Arrange
            var pageNumber = _getDocumentListQuery.validPaginationFilter.PageNumber;
            var pageSize = _getDocumentListQuery.validPaginationFilter.PageSize;
            var sortField = _getDocumentListQuery.validSortingFilter.SortField;
            var ascending = _getDocumentListQuery.validSortingFilter.Ascending;
            var filterBy = _getDocumentListQuery.filterBy;

            //Act
            await _getDocumentListHandler.Handle(_getDocumentListQuery, CancellationToken.None);

            //Assert
            _documentRepositoryMock.Verify(x => x.GetAllAsync(pageNumber, pageSize, sortField, ascending, filterBy), Times.Once);
        }

        [Fact]
        public async Task GetDocumentListHandler_GivenValidQuery_ShouldReturnCorrectTotalRecords()
        {
            //Arrange
            var pageNumber = _getDocumentListQuery.validPaginationFilter.PageNumber;
            var pageSize = _getDocumentListQuery.validPaginationFilter.PageSize;
            var sortField = _getDocumentListQuery.validSortingFilter.SortField;
            var ascending = _getDocumentListQuery.validSortingFilter.Ascending;
            var filterBy = _getDocumentListQuery.filterBy;

            var documents = new List<Document>()
            {
                new Document()
                {
                    Name = "test name1",
                    ReceivedAt = new DateTime(2021, 10, 6),
                    Cost = 1M,
                    Description = "test description1",
                },
                new Document()
                {
                    Name = "test name2",
                    ReceivedAt = new DateTime(2021, 10, 6),
                    Cost = 2M,
                    Description = "test description2",
                },
            };
            
            _mapperMock.Setup(x => x.Map<IEnumerable<GetDocumentDto>>(documents));
            _documentRepositoryMock.Setup(x => x.GetAllAsync(pageNumber, pageSize, sortField, ascending, filterBy)).ReturnsAsync(documents);
            
            //Act
            await _getDocumentListHandler.Handle(_getDocumentListQuery, CancellationToken.None);

            //Assert
            _documentRepositoryMock.Verify(x => x.TotalRecords(filterBy), Times.Once);
            //_documentRepositoryMock.Object.TotalRecords("test").Should().BeInRange(1, 3);

        }
    }
}

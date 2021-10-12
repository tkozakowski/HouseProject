using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Core.Paginations;
using Microsoft.Extensions.Logging;
using Domain.Interfaces;

namespace Application.Document.Query.GetDocuments
{
    public class GetDocumentListHandler : IRequestHandler<GetDocumentListQuery, PaginationResult<IEnumerable<GetDocumentDto>>>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetDocumentListHandler(IDocumentRepository documentRepository, IMapper mapper, ILogger<GetDocumentListHandler> logger)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PaginationResult<IEnumerable<GetDocumentDto>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {

            var documents = await _documentRepository.GetAllAsync(request.validPaginationFilter.PageNumber, request.validPaginationFilter.PageSize, 
                request.validSortingFilter.SortField, request.validSortingFilter.Ascending, request.filterBy);

            var documentsDto = _mapper.Map<IEnumerable<GetDocumentDto>>(documents);

            var totalRecords = _documentRepository.TotalRecords(request.filterBy);

            _logger.LogDebug($"Get {documents.Count()} results from {totalRecords} records");

            return HelperPaginationResult.HelperPaginationResultResponse<GetDocumentDto>(documentsDto, request.validPaginationFilter, totalRecords);
        }
    }
}

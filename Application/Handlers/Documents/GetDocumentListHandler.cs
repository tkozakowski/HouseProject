using AutoMapper;
using Application.Dto;
using Application.Queries.Documents;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Core.Paginations;
using Microsoft.Extensions.Logging;
using Domain.Interfaces;

namespace Application.Handlers.Documents
{
    public class GetDocumentListHandler : IRequestHandler<GetDocumentListQuery, PaginationResult<IEnumerable<DocumentDto>>>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetDocumentListHandler(IDocumentRepository documentRepository, IMapper mapper, ILogger<GetDocumentByIdHandler> logger)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PaginationResult<IEnumerable<DocumentDto>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {

            var documents = await _documentRepository.GetAllAsync(request.validPaginationFilter.PageNumber, request.validPaginationFilter.PageSize, 
                request.validSortingFilter.SortField, request.validSortingFilter.Ascending, request.filterBy);

            var documentsDto = _mapper.Map<IEnumerable<DocumentDto>>(documents);

            var totalRecords = _documentRepository.TotalRecords(request.filterBy);

            _logger.LogDebug($"Get {documents.Count()} results from {totalRecords} records");

            return HelperPaginationResult.HelperPaginationResultResponse<DocumentDto>(documentsDto, request.validPaginationFilter, totalRecords);
        }
    }
}

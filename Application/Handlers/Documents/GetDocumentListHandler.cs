using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Dto;
using Application.Queries.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Core.Paginations;
using Application.Extensions;
using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Documents
{
    public class GetDocumentListHandler : IRequestHandler<GetDocumentListQuery, PaginationResult<IEnumerable<DocumentDto>>>
    {
        private readonly IHouseProjectDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetDocumentListHandler(IHouseProjectDbContext context, IMapper mapper, ILogger<GetDocumentByIdHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PaginationResult<IEnumerable<DocumentDto>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {

            List<DocumentDto> result = await _context.Documents
                .Where(x => x.Name.ToLower().Contains(request.filterBy.ToLower()) || x.Description.ToLower().Contains(request.filterBy.ToLower()))
                .OrderByPropertyName(request.validSortingFilter.SortField, request.validSortingFilter.Ascending)
                .Skip((request.validPaginationFilter.PageNumber - 1) * request.validPaginationFilter.PageSize)
                .Take(request.validPaginationFilter.PageSize)
                .ProjectTo<DocumentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var totalRecords = _context.Documents
                .Where(x => x.Name.ToLower().Contains(request.filterBy.ToLower()) || x.Description.ToLower().Contains(request.filterBy.ToLower()))
                .Count();

            _logger.LogDebug($"Get {result.Count()} results from {totalRecords} records");

            return HelperPaginationResult.HelperPaginationResultResponse<DocumentDto>(result, request.validPaginationFilter, totalRecords);
        }
    }
}

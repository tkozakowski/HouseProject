using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Core.Paginations;
using Microsoft.Extensions.Logging;
using Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Document.Query.GetDocuments
{
    public class GetDocumentListHandler : IRequestHandler<GetDocumentListQuery, PaginationResult<IEnumerable<GetDocumentDto>>>
    {
        private readonly IHouseProjectDbContext _houseProjectDbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetDocumentListHandler(IHouseProjectDbContext houseProjectDbContext, IMapper mapper, ILogger<GetDocumentListHandler> logger)
        {
            _houseProjectDbContext = houseProjectDbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginationResult<IEnumerable<GetDocumentDto>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {

            var documentsDto = await _houseProjectDbContext.Documents.ProjectTo<GetDocumentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var totalRecords = _houseProjectDbContext.Documents.Where(x => x.Name.ToLower().Contains(request.filterBy.ToLower()) || x.Description.ToLower().Contains(request.filterBy.ToLower())).Count();

            _logger.LogDebug($"Get {documentsDto.Count()} results from {totalRecords} records");

            return HelperPaginationResult.HelperPaginationResultResponse<GetDocumentDto>(documentsDto, request.validPaginationFilter, totalRecords);
        }
    }
}

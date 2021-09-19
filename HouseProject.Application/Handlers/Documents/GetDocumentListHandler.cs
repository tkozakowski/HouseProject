using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Dto;
using Application.Queries.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using System.Linq;
using Application.Core.Paginations;

namespace Application.Handlers.Documents
{
    public class GetDocumentListHandler : IRequestHandler<GetDocumentListQuery, PaginationResult<IEnumerable<DocumentDto>>>
    {
        private readonly HouseProjectDbContext _context;
        private readonly IMapper _mapper;

        public GetDocumentListHandler(HouseProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginationResult<IEnumerable<DocumentDto>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {
            List<DocumentDto> result = await _context.Documents.Skip((request.validPaginationFilter.PageNumber - 1) * request.validPaginationFilter.PageSize)
                .Take(request.validPaginationFilter.PageSize).ProjectTo<DocumentDto>(_mapper.ConfigurationProvider).ToListAsync();

            var totalRecords = result.Count();

            return HelperPaginationResult.HelperPaginationResultResponse<DocumentDto>(result, request.validPaginationFilter, totalRecords);

            //return new PaginationResult<List<DocumentDto>>(result, request.validPaginationFilter.PageNumber, request.validPaginationFilter.PageSize);
        }
    }
}

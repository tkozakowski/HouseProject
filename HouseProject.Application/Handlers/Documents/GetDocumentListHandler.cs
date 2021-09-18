using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Core;
using Application.Dto;
using Application.Queries.Documents;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Persistence;

namespace Application.Handlers.Documents
{
    public class GetDocumentListHandler : IRequestHandler<GetDocumentListQuery, Result<List<DocumentDto>>>
    {
        private readonly HouseProjectDbContext _context;
        private readonly IMapper _mapper;

        public GetDocumentListHandler(HouseProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<List<DocumentDto>>> Handle(GetDocumentListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Documents.ProjectTo<DocumentDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Result<List<DocumentDto>>.Success(result);
        }
    }
}

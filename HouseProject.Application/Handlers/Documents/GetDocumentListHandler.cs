using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseProject.Application.Core;
using HouseProject.Application.Dto;
using HouseProject.Application.Queries.Documents;
using HouseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HouseProject.Application.Handlers.Documents
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

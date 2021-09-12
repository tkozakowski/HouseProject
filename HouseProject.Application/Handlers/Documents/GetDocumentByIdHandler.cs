using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseProject.Application.Core;
using HouseProject.Application.Dto;
using HouseProject.Application.Queries.Documents;
using HouseProject.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HouseProject.Application.Handlers.Documents
{
    public class GetDocumentByIdHandler : IRequestHandler<GetDocumentByIdQuery, Result<DocumentDto>>
    {
        private readonly HouseProjectDbContext _houseProjectContext;
        private readonly IMapper _mapper;

        public GetDocumentByIdHandler(HouseProjectDbContext houseProjectContext, IMapper mapper)
        {
            _houseProjectContext = houseProjectContext;
            _mapper = mapper;
        }
        public async Task<Result<DocumentDto>> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _houseProjectContext.Documents.Where(x => x.Id == request.id)
                .ProjectTo<DocumentDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return Result<DocumentDto>.Success(result);
        }
    }
}

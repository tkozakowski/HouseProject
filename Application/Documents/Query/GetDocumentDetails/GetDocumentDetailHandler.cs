using AutoMapper;
using Application.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Documents.Query.GetDocumentDetails;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Application.Documents.Query.Details
{
    //public class GetDocumentDetailHandler : IRequestHandler<GetDocumentDetailQuery, Response<DocumentDetailsDto>>
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IHouseProjectDbContext _houseProjectDbContext;

    //    public GetDocumentDetailHandler(IMapper mapper, IHouseProjectDbContext houseProjectDbContext)
    //    {
    //        _mapper = mapper;
    //        _houseProjectDbContext = houseProjectDbContext;
    //    }

    //    public async Task<Response<DocumentDetailsDto>> Handle(GetDocumentDetailQuery request, CancellationToken cancellationToken)
    //    {

    //        var result = await _houseProjectDbContext.Documents.Where(x => x.Id == request.id)
    //            .ProjectTo<DocumentDetailsDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (result is null) return Response<DocumentDetailsDto>.Failure("Failed to get document");

            return Response<DocumentDetailsDto>.Success(result);
        }
    }
}

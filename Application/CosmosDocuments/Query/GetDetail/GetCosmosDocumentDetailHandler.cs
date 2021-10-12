using Application.Core;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Query.GetDetail
{
    public class GetCosmosDocumentDetailHandler : IRequestHandler<GetCosmosDocumentByIdQuery, Response<GetCosmosDocumentDto>>
    {
        private readonly ICosmosDocumentRepository _cosmosDocumentRepository;
        private readonly IMapper _mapper;

        public GetCosmosDocumentDetailHandler(ICosmosDocumentRepository cosmosDocumentRepository, IMapper mapper)
        {
            _cosmosDocumentRepository = cosmosDocumentRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetCosmosDocumentDto>> Handle(GetCosmosDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var cosmosDocument = await _cosmosDocumentRepository.GetByIdAsync(request.id);
            var cosmosDocumentDto = _mapper.Map<GetCosmosDocumentDto>(cosmosDocument);

            return Response<GetCosmosDocumentDto>.Success(cosmosDocumentDto);
        }
    }
}

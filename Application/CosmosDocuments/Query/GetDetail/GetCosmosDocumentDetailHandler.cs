using Application.Core;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Query.GetDetail
{
    public class GetCosmosDocumentDetailHandler : IRequestHandler<GetCosmosDocumentByIdQuery, Result<GetCosmosDocumentDto>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        private readonly IMapper _mapper;

        public GetCosmosDocumentDetailHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Result<GetCosmosDocumentDto>> Handle(GetCosmosDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var cosmosDocument = await _cosmosStore.FindAsync(request.id);
            var cosmosDocumentDto = _mapper.Map<GetCosmosDocumentDto>(cosmosDocument);

            return Result<GetCosmosDocumentDto>.Success(cosmosDocumentDto);
        }
    }
}

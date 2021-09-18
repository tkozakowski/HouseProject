using Application.Core;
using Application.Dto.Cosmos;
using Application.Queries.CosmosDocuments;
using AutoMapper;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class GetCosmosDocumentByIdHandler : IRequestHandler<GetCosmosDocumentByIdQuery, Result<CosmosDocumentDto>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        private readonly IMapper _mapper;

        public GetCosmosDocumentByIdHandler(ICosmosStore<CosmosDocument> cosmosStore, IMapper mapper)
        {
            _cosmosStore = cosmosStore;
            _mapper = mapper;
        }

        public async Task<Result<CosmosDocumentDto>> Handle(GetCosmosDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var cosmosDocument = await _cosmosStore.FindAsync(request.Id);
            var cosmosDocumentDto = _mapper.Map<CosmosDocumentDto>(cosmosDocument);

            return Result<CosmosDocumentDto>.Success(cosmosDocumentDto);
        }
    }
}

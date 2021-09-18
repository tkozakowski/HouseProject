using Application.Core;
using Application.Queries.CosmosDocuments;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class GetCosmosDocumentByIdHandler : IRequestHandler<GetCosmosDocumentByIdQuery, Result<CosmosDocument>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;

        public GetCosmosDocumentByIdHandler(ICosmosStore<CosmosDocument> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<Result<CosmosDocument>> Handle(GetCosmosDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _cosmosStore.FindAsync(request.Id);

            return Result<CosmosDocument>.Success(response);
        }
    }
}

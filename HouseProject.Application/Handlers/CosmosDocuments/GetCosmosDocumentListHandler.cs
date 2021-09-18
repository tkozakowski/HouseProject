using Application.Core;
using Application.Queries.CosmosDocuments;
using Cosmonaut;
using Cosmonaut.Extensions;
using Domain.Entities.Cosmos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class GetCosmosDocumentListHandler : IRequestHandler<GetCosmosDocumentListQuery, Result<List<CosmosDocument>>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        public GetCosmosDocumentListHandler(ICosmosStore<CosmosDocument> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }
        public async Task<Result<List<CosmosDocument>>> Handle(GetCosmosDocumentListQuery request, CancellationToken cancellationToken)
        {
            var response = await _cosmosStore.Query().ToListAsync();

            return Result<List<CosmosDocument>>.Success(response);
        }
    }
}

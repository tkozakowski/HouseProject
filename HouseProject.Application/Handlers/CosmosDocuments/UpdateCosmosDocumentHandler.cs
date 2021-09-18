using Application.Command.CosmosDocuments;
using Application.Core;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class UpdateCosmosDocumentHandler : IRequestHandler<UpdateCosmosDocumentCommand, Result<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;

        public UpdateCosmosDocumentHandler(ICosmosStore<CosmosDocument> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<Result<Unit>> Handle(UpdateCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            await _cosmosStore.UpdateAsync(request.CosmosDocument);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}

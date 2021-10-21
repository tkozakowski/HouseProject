using Application.Core;
using Cosmonaut;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CosmosDocuments.Command.Remove
{
    public class RemoveCosmosDocumentHandler : IRequestHandler<RemoveCosmosDocumentCommand, Response<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;

        public RemoveCosmosDocumentHandler()
        {

        }

        public async Task<Response<Unit>> Handle(RemoveCosmosDocumentCommand request, CancellationToken cancellationToken)
        {

            var result = await _cosmosStore.RemoveByIdAsync(request.Id);

            if (!result.IsSuccess)
                return Response<Unit>.Failure("Failed to remove document");

            return Response<Unit>.Success(Unit.Value);
        }
    }
}

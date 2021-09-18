using Application.Command.CosmosDocuments;
using Application.Core;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class InsertCosmosDocumentHandler : IRequestHandler<InsertCosmosDocumentCommand, Result<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;
        public async Task<Result<Unit>> Handle(InsertCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            request.cosmosDocument.Id = Guid.NewGuid().ToString();
            await _cosmosStore.AddAsync(request.cosmosDocument);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}

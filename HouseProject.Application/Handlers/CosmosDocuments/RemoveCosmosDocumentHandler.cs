using Application.Command.CosmosDocuments;
using Application.Core;
using Cosmonaut;
using Domain.Entities.Cosmos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CosmosDocuments
{
    public class RemoveCosmosDocumentHandler : IRequestHandler<RemoveCosmosDocumentCommand, Result<Unit>>
    {
        private readonly ICosmosStore<CosmosDocument> _cosmosStore;

        public RemoveCosmosDocumentHandler(ICosmosStore<CosmosDocument> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<Result<Unit>> Handle(RemoveCosmosDocumentCommand request, CancellationToken cancellationToken)
        {
            await _cosmosStore.RemoveByIdAsync(request.Id);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}

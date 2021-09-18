using Application.Core;
using Domain.Entities.Cosmos;
using MediatR;

namespace Application.Command.CosmosDocuments
{
    public class UpdateCosmosDocumentCommand : IRequest<Result<Unit>>
    {
        public CosmosDocument CosmosDocument { get; set; }
    }
}

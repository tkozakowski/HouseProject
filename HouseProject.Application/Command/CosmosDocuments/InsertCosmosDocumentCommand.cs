using Application.Core;
using Domain.Entities.Cosmos;
using MediatR;

namespace Application.Command.CosmosDocuments
{
    public record InsertCosmosDocumentCommand(CosmosDocument cosmosDocument): IRequest<Result<Unit>>;

}

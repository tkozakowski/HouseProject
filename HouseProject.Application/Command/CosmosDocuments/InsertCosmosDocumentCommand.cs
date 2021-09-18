using Application.Core;
using Application.Dto.Cosmos;
using MediatR;

namespace Application.Command.CosmosDocuments
{
    public record InsertCosmosDocumentCommand(CosmosDocumentDto cosmosDocument): IRequest<Result<Unit>>;

}

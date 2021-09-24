using Application.Core;
using Application.Dto.Cosmos;
using MediatR;

namespace Application.Command.CosmosDocuments
{
    public class UpdateCosmosDocumentCommand : IRequest<Result<Unit>>
    {
        public CosmosDocumentDto CosmosDocumentDto { get; set; }
    }
}

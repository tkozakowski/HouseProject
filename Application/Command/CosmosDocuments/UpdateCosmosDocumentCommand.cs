using Application.Core;
using Application.Dto.Cosmos;
using MediatR;

namespace Application.Command.CosmosDocuments
{
    public class UpdateCosmosDocumentCommand : IRequest<Response<Unit>>
    {
        public CosmosDocumentDto CosmosDocumentDto { get; set; }
    }
}

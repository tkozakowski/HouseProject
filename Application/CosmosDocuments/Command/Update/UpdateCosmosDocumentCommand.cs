using Application.Core;
using MediatR;

namespace Application.CosmosDocuments.Command.Update
{
    public class UpdateCosmosDocumentCommand : IRequest<Result<Unit>>
    {
        public UpdateCosmosDocumentDto UpdateCosmosDocumentDto { get; set; }
    }
}

using Application.Core;
using MediatR;

namespace Application.CosmosDocuments.Command.Update
{
    public class UpdateCosmosDocumentCommand : IRequest<Response<Unit>>
    {
        public UpdateCosmosDocumentDto UpdateCosmosDocumentDto { get; set; }
    }
}

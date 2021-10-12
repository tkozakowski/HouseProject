using Application.Core;
using MediatR;

namespace Application.CosmosDocuments.Command.Remove
{
    public class RemoveCosmosDocumentCommand: IRequest<Response<Unit>>
    {
        public string Id { get; set; }
    }
}

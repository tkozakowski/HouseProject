using Application.Core;
using MediatR;

namespace Application.Command.CosmosDocuments
{
    public class RemoveCosmosDocumentCommand: IRequest<Response<Unit>>
    {
        public string Id { get; set; }
    }
}

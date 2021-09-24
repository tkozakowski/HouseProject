using Application.Core;
using MediatR;

namespace Application.Command.CosmosDocuments
{
    public class RemoveCosmosDocumentCommand: IRequest<Result<Unit>>
    {
        public string Id { get; set; }
    }
}

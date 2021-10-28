using Application.Core;
using MediatR;

namespace Application.CosmosDocuments.Command.Create
{
    public class InsertCosmosDocumentCommand: IRequest<Result<Unit>>
    {
        public CreateCosmosDocumentDto CosmosDocument { get; set; }
    }

}

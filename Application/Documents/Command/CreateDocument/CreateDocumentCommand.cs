using Application.Core;
using MediatR;

namespace Application.Documents.Command.CreateDocument
{
    public class CreateDocumentCommand: IRequest<Result<Unit>>
    {
        public CreateDocumentDto CreateDocumentDto { get; set; }
        public string UserId { get; set; }
    }

}

using Application.Core;
using MediatR;

namespace Application.Documents.Command.InsertDocument
{
    public class InsertDocumentCommand: IRequest<Response<Unit>>
    {
        public CreateDocumentDto CreateDocumentDto { get; set; }
        public string UserId { get; set; }
    }

}

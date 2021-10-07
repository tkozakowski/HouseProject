using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Command.Documents
{
    public class InsertDocumentCommand: IRequest<Response<Unit>>
    {
        public CreateDocumentDto CreateDocumentDto { get; set; }
        public string UserId { get; set; }
    }

}

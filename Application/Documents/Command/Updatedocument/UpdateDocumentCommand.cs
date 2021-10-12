using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Documents.Command.UpdateDocument
{
    public class UpdateDocumentCommand: IRequest<Response<Unit>>
    {
        public int Id { get; set; }
        public UpdateDocumentDto DocumentDto { get; set; }
        public string UserId { get; set; }
    }
}

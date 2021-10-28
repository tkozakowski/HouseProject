using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Documents.Command.UpdateDocument
{
    public class UpdateDocumentCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public UpdateDocumentDto UpdateDocumentDto { get; set; }
        public string UserId { get; set; }
    }
}

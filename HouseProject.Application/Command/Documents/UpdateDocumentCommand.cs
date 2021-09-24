using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Command.Documents
{
    public class UpdateDocumentCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public DocumentDto DocumentDto { get; set; }
        public string UserId { get; set; }
    }
}

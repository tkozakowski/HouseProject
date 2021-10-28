using Application.Core;
using MediatR;

namespace Application.Documents.Command.RemoveDocument
{
    public class RemoveDocumentCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}

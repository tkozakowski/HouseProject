using Application.Core;
using MediatR;

namespace Application.Command.Documents
{
    public class RemoveDocumentCommand: IRequest<Response<Unit>>
    {
        public int Id { get; set; }
    }
}

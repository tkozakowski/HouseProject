using HouseProject.Application.Core;
using MediatR;

namespace HouseProject.Application.Command.Documents
{
    public class RemoveDocumentCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}

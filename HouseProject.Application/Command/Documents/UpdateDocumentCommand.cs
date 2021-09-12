using HouseProject.Application.Core;
using HouseProject.Application.Dto;
using MediatR;

namespace HouseProject.Application.Command.Documents
{
    public class UpdateDocumentCommand: IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public DocumentDto DocumentDto { get; set; }
    }
}

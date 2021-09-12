using HouseProject.Application.Core;
using HouseProject.Application.Dto;
using MediatR;

namespace HouseProject.Application.Command.Documents
{
    public record InsertDocumentCommand(DocumentDto documentDto): IRequest<Result<Unit>>;

}

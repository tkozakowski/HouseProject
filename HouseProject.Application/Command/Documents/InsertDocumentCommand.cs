using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Command.Documents
{
    public record InsertDocumentCommand(DocumentDto documentDto): IRequest<Result<Unit>>;

}

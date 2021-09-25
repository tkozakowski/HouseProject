using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Command.Documents
{
    public record InsertDocumentCommand(CreateDocumentDto documentDto, string userId): IRequest<Response<Unit>>;

}

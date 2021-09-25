using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Queries.Documents
{
    public record GetDocumentByIdQuery(int id): IRequest<Response<DocumentDto>>;

}

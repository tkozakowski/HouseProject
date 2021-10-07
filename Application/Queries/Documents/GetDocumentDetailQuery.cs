using Application.Core;
using Application.Dto;
using MediatR;

namespace Application.Queries.Documents
{
    public record GetDocumentDetailQuery(int id): IRequest<Response<DocumentDto>>;

}

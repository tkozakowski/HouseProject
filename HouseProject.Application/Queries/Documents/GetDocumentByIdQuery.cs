using HouseProject.Application.Core;
using HouseProject.Application.Dto;
using MediatR;

namespace HouseProject.Application.Queries.Documents
{
    public record GetDocumentByIdQuery(int id): IRequest<Result<DocumentDto>>;

}

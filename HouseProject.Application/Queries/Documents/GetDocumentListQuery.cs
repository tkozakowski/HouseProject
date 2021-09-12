using HouseProject.Application.Core;
using HouseProject.Application.Dto;
using MediatR;
using System.Collections.Generic;

namespace HouseProject.Application.Queries.Documents
{
    public record GetDocumentListQuery : IRequest<Result<List<DocumentDto>>>;

}

using Application.Core;
using Application.Dto;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Documents
{
    public record GetDocumentListQuery : IRequest<Result<List<DocumentDto>>>;

}

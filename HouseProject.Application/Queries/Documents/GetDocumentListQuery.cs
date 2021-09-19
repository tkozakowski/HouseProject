using Application.Core.Paginations;
using Application.Dto;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Documents
{
    public record GetDocumentListQuery(PaginationFilter validPaginationFilter) : IRequest<PaginationResult<IEnumerable<DocumentDto>>>;
}

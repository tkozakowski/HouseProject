using Application.Core.Paginations;
using Application.Core.Sortings;
using Application.Dto;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Documents
{
    public record GetDocumentListQuery(PaginationFilter validPaginationFilter, SortingFilter validSortingFilter, string filterBy) 
        : IRequest<PaginationResult<IEnumerable<DocumentDto>>>;
}

using Application.Core.Paginations;
using Application.Core.Sortings;
using MediatR;
using System.Collections.Generic;

namespace Application.Document.Query.GetDocuments
{
    public record GetDocumentListQuery(PaginationFilter validPaginationFilter, SortingFilter validSortingFilter, 
        string filterBy)  : IRequest<PaginationResult<IEnumerable<GetDocumentDto>>>;
}

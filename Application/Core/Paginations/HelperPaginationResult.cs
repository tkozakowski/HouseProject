using System;
using System.Collections.Generic;

namespace Application.Core.Paginations
{
    public class HelperPaginationResult
    {
        public static PaginationResult<IEnumerable<T>> HelperPaginationResultResponse<T>(IEnumerable<T> pagedData, PaginationFilter validPaginationFilter, int totalRecords)
        {
            var response = new PaginationResult<IEnumerable<T>>(pagedData, validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validPaginationFilter.PageSize);
            var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            int currentPage = validPaginationFilter.PageNumber;

            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            response.ExistPreviousPage = currentPage > 1 ? true : false;
            response.ExistNextPage = currentPage < roundedTotalPages ? true : false;

            return response;
        }
    }
}

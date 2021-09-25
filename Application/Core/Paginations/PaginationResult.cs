namespace Application.Core.Paginations
{
    public class PaginationResult<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public bool ExistNextPage { get; set; }
        public bool ExistPreviousPage { get; set; }

        public PaginationResult(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Value = data;
            IsSuccess = true;
        }
    }
}

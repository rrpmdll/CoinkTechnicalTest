namespace Coink.Microservice.Domain.Common
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public int? PreviousPageNumber => HasPreviousPage ? PageNumber - 1 : null;
        public int? NextPageNumber => HasNextPage ? PageNumber + 1 : null;

        public PagedResult()
        {
        }

        public PagedResult(
            IEnumerable<T> items, 
            int totalCount, 
            int pageNumber, 
            int pageSize
        )
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public static PagedResult<T> Empty() => new(new List<T>(), 0, 1, 10);

        public static PagedResult<T> Create(IEnumerable<T> items, int totalCount, PaginationParameters parameters)
            => new(items, totalCount, parameters.PageNumber, parameters.PageSize);
    }
}

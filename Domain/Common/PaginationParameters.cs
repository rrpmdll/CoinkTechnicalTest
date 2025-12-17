namespace Coink.Microservice.Domain.Common
{
    public class PaginationParameters
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        public string? OrderBy { get; set; }
        public string OrderDirection { get; set; } = "asc";
        public bool IsDescending => OrderDirection?.ToLower() == "desc";
        public string? SearchTerm { get; set; }
    }
}

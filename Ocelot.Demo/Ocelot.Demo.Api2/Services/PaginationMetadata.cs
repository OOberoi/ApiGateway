namespace Ocelot.Demo.Api2.Services
{
    public class PaginationMetadata
    {
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginationMetadata(int totalItemCount, int totalPageCount, int pageSize, int currentPage)
        {
            TotalItemCount = totalItemCount;
            TotalPageCount = totalPageCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }

    }
}

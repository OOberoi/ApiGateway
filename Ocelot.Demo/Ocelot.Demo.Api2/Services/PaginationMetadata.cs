namespace Ocelot.Demo.Api2.Services
{
    /// <summary>
    /// A calss that is used to handle paging
    /// </summary>
    public class PaginationMetadata
    {
        /// <summary>
        /// Item count
        /// </summary>
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginationMetadata(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItemCount = totalItemCount;            
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }

    }
}

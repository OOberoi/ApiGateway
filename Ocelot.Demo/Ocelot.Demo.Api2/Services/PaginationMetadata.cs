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

        /// <summary>
        /// Total page count
        /// </summary>
        public int TotalPageCount { get; set; }
        /// <summary>
        /// Total page size i.e. 5, 10, 15 etc.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Current page in scope
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="totalItemCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        public PaginationMetadata(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItemCount = totalItemCount;            
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }

    }
}

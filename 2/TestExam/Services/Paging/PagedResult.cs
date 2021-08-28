using System.Collections.Generic;

namespace Services.Paging
{
    public class PagedResult<T>
    {
        public int CurrentPage { get; set; }
        public int ResultsPerPage { get; set; }
        public ICollection<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
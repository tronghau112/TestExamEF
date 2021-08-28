using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Paging
{
    public static class Extensions
    {
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int page, int numberPerPage)
        {
            numberPerPage = Math.Abs(numberPerPage);
            page = Math.Abs(page);
            page = page > 0 ? page : 1;
            var pageCount = new int?();

            var totalCount = await query.CountAsync();
            var pageIndex = page - 1;

            if (numberPerPage > 0)
            {
                var modResult = totalCount % numberPerPage == 0 ? 0 : 1;
                pageCount = totalCount / numberPerPage + modResult;
            }

            return new PagedResult<T>
            {
                CurrentPage = page,
                ResultsPerPage = numberPerPage,
                TotalCount = totalCount,
                Data = await query
                    .Skip(pageIndex * numberPerPage)
                    .Take(numberPerPage)
                    .ToListAsync(),
                TotalPages = pageCount.GetValueOrDefault()
            };
        }
    }
}
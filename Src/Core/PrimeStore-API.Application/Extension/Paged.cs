using Microsoft.EntityFrameworkCore;

namespace PrimeStore_API.Application.Extension
{
    public static class Paged
    {
        public static IEnumerable<T> ToPagedList<T>(this IQueryable<T> query,int page,int pageSize)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public static async Task<IEnumerable<T>> ToPagedListAsync<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var items = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
            return items;
        }

    }
}

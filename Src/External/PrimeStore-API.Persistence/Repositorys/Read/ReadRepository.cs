using Microsoft.EntityFrameworkCore;
using PrimeStore_API.Application.Repositorys.Read;
using PrimeStore_API.Domanin.Entities.BaseClass;
using PrimeStore_API.Persistence.Context;
using System.Linq.Expressions;

namespace PrimeStore_API.Persistence.Repositorys.Read
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _context;
        private readonly DbSet<T> _dbSet;
        public ReadRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return expression != null ? await _dbSet.FirstOrDefaultAsync(expression) : await _dbSet.FirstOrDefaultAsync();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = expression != null ? _dbSet.Where(expression) : _dbSet;

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            var query = expression != null ? _dbSet.Where(expression) : _dbSet;

            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return expression != null ? await _dbSet.SingleOrDefaultAsync(expression) : await _dbSet.SingleOrDefaultAsync();
        }
    }
}

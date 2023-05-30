using PrimeStore_API.Domanin.Entities.BaseClass;
using System.Linq.Expressions;

namespace PrimeStore_API.Application.Repositorys.Read
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, bool tracking = true);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
     
    }
}

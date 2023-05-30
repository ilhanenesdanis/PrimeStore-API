using PrimeStore_API.Application.RequestParameters;
using PrimeStore_API.Domanin.Entities.BaseClass;
using System.Linq.Expressions;

namespace PrimeStore_API.Application.Repositorys.Dapper
{
    public interface IDapperRepository<T> where T : BaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> selectColumns = null, string orderByColumn = null, bool ascending = true, Pagination Pagination = null);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetByAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> selectColumns = null, string orderByColumn = null, bool ascending = true, Pagination Pagination = null);
        Task<IEnumerable<object>> GetAllDynamicAsync(string query);
        Task<object> GetByDynamicAsync(string query);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}

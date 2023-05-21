using PrimeStore_API.Domanin.Entities.BaseClass;

namespace PrimeStore_API.Application.Repositorys.Write
{
    public interface IWriteRepository<T> where T :BaseEntity
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
       

    }
}

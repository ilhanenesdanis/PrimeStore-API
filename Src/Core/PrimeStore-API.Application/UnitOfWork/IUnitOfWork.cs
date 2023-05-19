using PrimeStore_API.Application.Repositorys.Read;

namespace PrimeStore_API.Application.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        #region ReadRepository
        IBrandReadRepository BrandReadRepository { get; }
        #endregion

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

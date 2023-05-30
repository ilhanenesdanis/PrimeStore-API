using PrimeStore_API.Application.Repositorys.Read;
using PrimeStore_API.Application.Repositorys.Write;

namespace PrimeStore_API.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        #region ReadRepository
        IBrandReadRepository BrandReadRepository { get; }
        IColorReadRepository ColorReadRepository { get; }
        #endregion
        #region WriteRepository
        IBrandWriteRepository BrandWriteRepository { get; }
        IColorWriteRepository ColorWriteRepository { get; }

        #endregion
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

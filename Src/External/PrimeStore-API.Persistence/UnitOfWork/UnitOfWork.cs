using PrimeStore_API.Application.Repositorys.Read;
using PrimeStore_API.Application.Repositorys.Write;
using PrimeStore_API.Application.UnitOfWork;
using PrimeStore_API.Persistence.Context;
using PrimeStore_API.Persistence.Repositorys.Read;
using PrimeStore_API.Persistence.Repositorys.Write;

namespace PrimeStore_API.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IBrandWriteRepository _brandWriteRepository;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            _brandReadRepository=new BrandReadRepository(context);
            _brandWriteRepository=new BrandWriteRepository(context);
        }

        public IBrandReadRepository BrandReadRepository => _brandReadRepository;

        public IBrandWriteRepository BrandWriteRepository => _brandWriteRepository;

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

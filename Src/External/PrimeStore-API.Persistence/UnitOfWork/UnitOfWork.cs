using PrimeStore_API.Application.Repositorys.Read;
using PrimeStore_API.Application.UnitOfWork;
using PrimeStore_API.Persistence.Context;
using PrimeStore_API.Persistence.Repositorys.Read;

namespace PrimeStore_API.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IBrandReadRepository _brandReadRepository;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            _brandReadRepository=new BrandReadRepository(context);
        }

        public IBrandReadRepository BrandReadRepository => _brandReadRepository;

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
    }
}

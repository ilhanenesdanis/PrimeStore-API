using PrimeStore_API.Application.Repositorys.Write;
using PrimeStore_API.Domanin.Entities;
using PrimeStore_API.Persistence.Context;

namespace PrimeStore_API.Persistence.Repositorys.Write
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

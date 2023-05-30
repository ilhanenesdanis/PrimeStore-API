using PrimeStore_API.Application.Repositorys.Write;
using PrimeStore_API.Domanin.Entities;
using PrimeStore_API.Persistence.Context;

namespace PrimeStore_API.Persistence.Repositorys.Write
{
    public class ColorWriteRepository : WriteRepository<Color>, IColorWriteRepository
    {
        public ColorWriteRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

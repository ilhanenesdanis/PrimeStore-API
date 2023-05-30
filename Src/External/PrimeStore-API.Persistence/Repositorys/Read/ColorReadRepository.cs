using PrimeStore_API.Application.Repositorys.Read;
using PrimeStore_API.Domanin.Entities;
using PrimeStore_API.Persistence.Context;

namespace PrimeStore_API.Persistence.Repositorys.Read
{
    public class ColorReadRepository : ReadRepository<Color>, IColorReadRepository
    {
        public ColorReadRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

using MediatR;
using PrimeStore_API.Application.Extension;
using PrimeStore_API.Application.Repositorys.Dapper;
using PrimeStore_API.Application.UnitOfWork;

namespace PrimeStore_API.Application.Features.Queries.Brand.GetAllBrandQueries
{
    public class GetAllBrandHandler : IRequestHandler<GetAllBrandRequest, IEnumerable<GetAllBrandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDapperRepository<PrimeStore_API.Domanin.Entities.Brand> _dapperRepository;
        public GetAllBrandHandler(IUnitOfWork unitOfWork, IDapperRepository<Domanin.Entities.Brand> dapperRepository)
        {
            _unitOfWork = unitOfWork;
            _dapperRepository = dapperRepository;
        }

        public async Task<IEnumerable<GetAllBrandResponse>> Handle(GetAllBrandRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<GetAllBrandResponse> result = await _unitOfWork.BrandReadRepository.GetAll(x => x.IsDeleted == false && x.IsEnabled == true, false)
                   .Select(x => new GetAllBrandResponse
                   {
                       BrandId = x.Id.ToString(),
                       BrandName = x.BrandName
                   }).ToPagedListAsync(request.Pagination.Page, request.Pagination.Size);

            //todo: Dapper Repository Test Edildi burdaki kod silinecek silinecek

            //var results = _dapperRepository.GetAllAsync(x => new { x.BrandName, x.CreateDate }, ascending: false, Pagination: request.Pagination, orderByColumn: "CreateDate").Result.Select(x=>new GetAllBrandResponse
            //{
            //    BrandId=x.Id.ToString(),
            //    BrandName=x.BrandName
            //}).ToList();

          

            return results;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using PrimeStore_API.Application.UnitOfWork;

namespace PrimeStore_API.Application.Features.Queries.Brand.GetAllBrandQueries
{
    public class GetAllBrandHandler : IRequestHandler<GetAllBrandRequest, List<GetAllBrandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllBrandResponse>> Handle(GetAllBrandRequest request, CancellationToken cancellationToken)
        {
            List<GetAllBrandResponse> result = await _unitOfWork.BrandReadRepository.GetAll(x => x.IsDeleted == false && x.IsEnabled == true, false)
                   .Skip((request.Pagination.Page - 1) * request.Pagination.Size).Take(request.Pagination.Size).Select(x => new GetAllBrandResponse
                   {
                       BrandId = x.Id.ToString(),
                       BrandName = x.BrandName
                   }).ToListAsync();
            return result;
        }
    }
}

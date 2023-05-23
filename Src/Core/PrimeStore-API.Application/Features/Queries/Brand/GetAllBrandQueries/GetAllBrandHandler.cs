using MediatR;
using Microsoft.EntityFrameworkCore;
using PrimeStore_API.Application.Extension;
using PrimeStore_API.Application.UnitOfWork;

namespace PrimeStore_API.Application.Features.Queries.Brand.GetAllBrandQueries
{
    public class GetAllBrandHandler : IRequestHandler<GetAllBrandRequest, IEnumerable<GetAllBrandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBrandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllBrandResponse>> Handle(GetAllBrandRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<GetAllBrandResponse> result = await _unitOfWork.BrandReadRepository.GetAll(x => x.IsDeleted == false && x.IsEnabled == true, false)
                   .Select(x => new GetAllBrandResponse
                   {
                       BrandId = x.Id.ToString(),
                       BrandName = x.BrandName
                   }).ToPagedListAsync(request.Pagination.Page,request.Pagination.Size);

            return result;
        }
    }
}

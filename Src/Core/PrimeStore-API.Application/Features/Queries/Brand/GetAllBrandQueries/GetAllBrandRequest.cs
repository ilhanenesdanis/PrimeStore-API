using MediatR;
using PrimeStore_API.Application.DTO;
using PrimeStore_API.Application.RequestParameters;

namespace PrimeStore_API.Application.Features.Queries.Brand.GetAllBrandQueries
{
    public class GetAllBrandRequest:IRequest<List<GetAllBrandResponse>>
    {
        public Pagination Pagination { get; set; }
    }
}

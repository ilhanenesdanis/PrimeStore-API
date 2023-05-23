using MediatR;
using PrimeStore_API.Application.DTO;
using PrimeStore_API.Application.RequestParameters;

namespace PrimeStore_API.Application.Features.Command.Brand.CreateBrandCommand
{
    public class CreateBrandCommandRequest : IRequest<ResultDTO<CreateBrandCommandResponse>>
    {
        public string BrandName { get; set; }

    }
}

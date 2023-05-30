using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrimeStore_API.Application.DTO;
using PrimeStore_API.Application.Features.Command.Brand.CreateBrandCommand;
using PrimeStore_API.Application.Features.Queries.Brand.GetAllBrandQueries;
using PrimeStore_API.Application.RequestParameters;

namespace PrimeStore_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("AddNewBrand")]
        [HttpPost]
        public async Task<IActionResult> AddNewBrand(CreateBrandCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreateActionResult(ResultDTO<CreateBrandCommandRequest>.Success(200));
        }
        [Route("GetAllBrands")]
        [HttpGet]
        public async Task<IActionResult> GetAllBrand([FromQuery]Pagination pagination)
        {
            var result = await _mediator.Send(new GetAllBrandRequest() { Pagination = pagination });
            return Ok(ResultDTO<IEnumerable<GetAllBrandResponse>>.Success(200,result));
        }
    }
}

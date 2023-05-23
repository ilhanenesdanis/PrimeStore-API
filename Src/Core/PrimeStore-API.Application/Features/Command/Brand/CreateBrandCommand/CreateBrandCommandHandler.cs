using MediatR;
using Microsoft.Extensions.Logging;
using PrimeStore_API.Application.DTO;
using PrimeStore_API.Application.UnitOfWork;
using System.Net;

namespace PrimeStore_API.Application.Features.Command.Brand.CreateBrandCommand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, ResultDTO<CreateBrandCommandResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateBrandCommandHandler> _logger;
        public CreateBrandCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateBrandCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ResultDTO<CreateBrandCommandResponse>> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.BrandName))
                return new ResultDTO<CreateBrandCommandResponse>()
                {
                    Data = null,
                    StatusCode = (int)HttpStatusCode.BadRequest,

                };

            Domanin.Entities.Brand brand = new Domanin.Entities.Brand()
            {
                BrandName = request.BrandName,
            };

            await _unitOfWork.BrandWriteRepository.AddAsync(brand);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if(result==0)
            {
                _logger.LogWarning(request.ToString());
                return new ResultDTO<CreateBrandCommandResponse>()
                {
                    Data = null,
                    StatusCode = (int)HttpStatusCode.BadRequest,

                };
            }
            return new ResultDTO<CreateBrandCommandResponse>()
            {
                StatusCode = (int)HttpStatusCode.OK,
            };

        }
    }
}

using MediatR;
using Microsoft.Extensions.Logging;
using PrimeStore_API.Application.UnitOfWork;

namespace PrimeStore_API.Application.Features.Command.Color.CreateColor
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommandRequest, CreateColorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateColorCommandHandler> _logger;
        public CreateColorCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateColorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CreateColorCommandResponse> Handle(CreateColorCommandRequest request, CancellationToken cancellationToken)
        {
            //todo: validasyon eklenecek
            
            Domanin.Entities.Color color = new Domanin.Entities.Color()
            {
                ColorName = request.ColorName,
                ColorCode = request.ColorCode,
                ColorHtmlCode = request.ColorHtmlCode,
            };
            await _unitOfWork.ColorWriteRepository.AddAsync(color);
            int result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (result == 0)
            {
                _logger.LogWarning(request.ToString());
                return new CreateColorCommandResponse();
            }
            return new CreateColorCommandResponse();
        }
    }
}

using MediatR;

namespace PrimeStore_API.Application.Features.Command.Color.CreateColor
{
    public class CreateColorCommandRequest:IRequest<CreateColorCommandResponse>
    {
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string ColorHtmlCode { get; set; }
    }
}

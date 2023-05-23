using PrimeStore_API.Application.DTO;
using System.Net;

namespace PrimeStore_API.API.Middleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var errorResponse = new ErrorModelDTO
            {
                Status = false
            };

            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            errorResponse.Message = exception.Message;
            errorResponse.StackTrace = !string.IsNullOrWhiteSpace(exception.StackTrace) ? exception.StackTrace : "";
            errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(errorResponse.ToString());
            await context.Response.WriteAsync(errorResponse.ToString());
        }
    }
}

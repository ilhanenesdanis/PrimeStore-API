using Microsoft.AspNetCore.Mvc;
using PrimeStore_API.Application.DTO;

namespace PrimeStore_API.API.Controllers
{

    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResultDTO<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}

using Course.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course.Shared.Base;

public class CustomBaseController : ControllerBase
{
    public IActionResult CreateActionResult<T>(ApiResponse<T> response)
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}
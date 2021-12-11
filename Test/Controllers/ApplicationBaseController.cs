using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public abstract class ApplicationBaseController : ControllerBase
    {
        protected ApiResult<T> Ok<T>(T data)
        {
            return ApiResult<T>.Ok(data);
        }
    }
}

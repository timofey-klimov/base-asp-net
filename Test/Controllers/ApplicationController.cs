using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("weather")]
    public class ApplicationController : ApplicationBaseController
    {
        private readonly IStringService _stringService;
        public ApplicationController(
            IStringService stringService)
        {
            _stringService = stringService;
        }

        [HttpGet("getWeather/{id}/{name}/{surname}")]
        public ApiResult<string> Test(int id, string name, string surname)
        {
            return Ok("Hello");
        }

        [HttpPost("postWeather/{id}")]
        public ApiResult<string> PostTest([FromBody] StringWrapper wrapper, int id)
        {
            var result = _stringService.DoSmth(wrapper.Value);

            return Ok(result);
        }
    }
}

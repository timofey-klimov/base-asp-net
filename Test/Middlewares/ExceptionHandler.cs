using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Test.Exceptions;
using Test.Models;

namespace Test.Middlewares
{
    public class ExceptionHandler
    {
        private RequestDelegate _next;
        public ExceptionHandler(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var apiResult = ApiResult.InternalError();

                if (ex is ApiException apiEx)
                    apiResult = new ApiResult(apiEx.Code, apiEx.Message);


                var stringResult = JsonConvert.SerializeObject(apiResult);

                await httpContext.Response.WriteAsync(stringResult);
            }
        }
    }
}

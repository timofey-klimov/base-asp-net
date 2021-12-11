using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Test.Middlewares
{
    public class LogMiddleware
    {
        private RequestDelegate _next;
        public LogMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stream = httpContext.Request.Body;
            using (var streamReader = new StreamReader(stream))
            {
                var result = await streamReader.ReadToEndAsync();
            }


            await _next(httpContext);
        }
    }
}

using Newtonsoft.Json;

namespace Test.Models
{
    public class ApiResult
    {
        public int Code { get; } // code

        public string Message { get; } // message

        public ApiResult(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public static ApiResult InternalError() => new ApiResult(500, "Unhadled exception");
    }

    public class ApiResult<T> : ApiResult
    {
        public T Data { get; }

        public ApiResult(T data, int code, string message)
            : base(code, message)
        {
            Data = data;
        }

        public static ApiResult<T> Ok(T data) => new ApiResult<T>(data, 200, string.Empty);

        public static ApiResult<T> Failt(int code, string message) => new ApiResult<T>(default(T), code, message);
    }
}

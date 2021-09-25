using System.Collections.Generic;

namespace Application.Core
{
    public class Response<T> : Response
    {
        public T Value { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static Response<T> Success(T value) => new Response<T> { IsSuccess = true, Value = value };
        public static Response<T> Failure(string error) => new Response<T> { Error = error };
        public static Response<T> Failure(string error, IEnumerable<string> errors) => new Response<T> { Error = error, Errors = errors };

    }

    public class Response
    {
        public Response() { }

        public Response(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }
}
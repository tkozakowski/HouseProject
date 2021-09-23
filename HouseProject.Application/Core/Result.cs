using System.Collections.Generic;

namespace Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
        public static Result<T> Failure(string error) => new Result<T> { Error = error };
        public static Result<T> Failure(string error, IEnumerable<string> errors) => new Result<T> { Error = error, Errors = errors };

    }
}
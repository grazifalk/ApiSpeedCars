using FluentValidation.Results;

namespace Service.Exceptions
{
    public class ResultService
    {
        public int? Code { get; set; }

        public string? Message { get; set; }

        public ICollection<ErrorValidation>? Errors { get; set; }

        public static ResultService RequestError(int code, string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                Code = code,
                Message = message,
                Errors = validationResult.Errors.Select
                (x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(int code, string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                Code = code,
                Message = message,
                Errors = validationResult.Errors.Select
                (x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail(int code, string message) => new ResultService { Code = code, Message = message };

        public static ResultService<T> Fail<T>(int code, string message) => new ResultService<T> { Code = code, Message = message };

        public static ResultService Ok(int code, string message) => new ResultService { Code = code, Message = message };

        public static ResultService<T> Ok<T>(int code, T Data) => new ResultService<T> { Code = code, Data = Data };
    }
    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }

}

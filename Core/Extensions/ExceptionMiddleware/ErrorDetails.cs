using FluentValidation.Results;
using Newtonsoft.Json;

namespace Core.Extensions.ExceptionMiddleware {
    public class ErrorDetails {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
    public class ValidationErrorDetails : ErrorDetails {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}
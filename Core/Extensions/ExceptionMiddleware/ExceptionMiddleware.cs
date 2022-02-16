using Core.Utilities.Messages;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Extensions.ExceptionMiddleware {
    public class ExceptionMiddleware {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await _next(httpContext);
            } catch (Exception exception) {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception) {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            String message = Messages.InternalServerError;
            if (exception.GetType().Equals(typeof(ValidationException))) {
                message = exception.Message;
                IEnumerable<ValidationFailure> validationErrors = ((ValidationException)exception).Errors;
                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync(new ValidationErrorDetails {
                    StatusCode = 400,
                    Message = message,
                    ValidationErrors = validationErrors
                }.ToString());
            }
            return httpContext.Response.WriteAsync(new ErrorDetails {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
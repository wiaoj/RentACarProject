using Microsoft.AspNetCore.Builder;

namespace Core.Extensions.ExceptionMiddleware {
    public static class ExceptionMiddlewareExtensions {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
    }
}
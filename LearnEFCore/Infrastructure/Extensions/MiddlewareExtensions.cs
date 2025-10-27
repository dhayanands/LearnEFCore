using LearnEFCore.Infrastructure.Middleware;

namespace LearnEFCore.Infrastructure.Extensions
{
 public static class MiddlewareExtensions
 {
 public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
 {
 app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
 return app;
 }
 }
}
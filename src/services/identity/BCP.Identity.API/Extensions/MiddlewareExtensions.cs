using BCP.Identity.API.Middleware;

namespace BCP.Identity.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAdMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<AdUserMiddleware>();
    }
}
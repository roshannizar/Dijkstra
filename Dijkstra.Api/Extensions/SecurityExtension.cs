using Dijkstra.Api.Middleware;

namespace Dijkstra.Api.Extensions
{
    public static class SecurityExtension
    {
        public static void AddSecurityMiddleware(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseMiddleware<ErrorMiddleware>();
        }
    }
}

namespace Dijkstra.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSecurityExtension(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}

namespace Dijkstra.Api.Extensions
{
    public static class CoreExtension
    {
        public static void AddCoreExtension(this IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();
        }

        public static void AddCoreMiddleware(this IApplicationBuilder app)
        {
            app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseHttpsRedirection();
        }
    }
}

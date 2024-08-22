using Dijkstra.Core.Services;
using Dijkstra.Infrastructure.Services;

namespace Dijkstra.Api.Extensions
{
    public static class AppExtension
    {
        public static void AddAppExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAlgorithmService, AlgorithmService>();
        }
    }
}

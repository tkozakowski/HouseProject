using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions.AddServices
{
    public static class HealthCheckService
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services)
        {

            services.AddHealthChecks()
                .AddDbContextCheck<HouseProjectDbContext>();
            return services;
        }
    }
}

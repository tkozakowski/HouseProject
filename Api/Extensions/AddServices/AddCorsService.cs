using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions.AddServices
{
    public static class AddCorsService
    {
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            return services;
        }
    }
}

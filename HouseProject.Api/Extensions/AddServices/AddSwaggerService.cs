using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OData.Swagger.Services;

namespace Api.Extensions.AddServices
{
    public static class AddSwaggerService
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HouseProject", Version = "v1" });
            });

            services.AddOdataSwaggerSupport();

            return services;
        }
    }
}

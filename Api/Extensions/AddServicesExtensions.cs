using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Api.Middleware;
using Application.Extensions;
using Api.Extensions.AddServices;
using Infrastructure.Extensions;
using System.Reflection;

namespace Api.Extensions
{
    public static class AddServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddSwagger();

            //services.AddCORS();


            services.AddInfrastructure(Configuration);

            services.AddApplication(Configuration);

            services.AddIdentityService(Configuration);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddVersioning();

            services.AddAuthorization();

            services.AddHealthCheck();


            //services.AddOData();

            return services;
        }

    }
}

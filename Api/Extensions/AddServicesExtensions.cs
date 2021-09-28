using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Handlers.Documents;
using Api.Middleware;
using Application.Extensions;
using Api.Extensions.AddServices;
using Infrastructure.Extensions;

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

            services.AddMediatR(typeof(GetDocumentListHandler).Assembly);

            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddVersioning();

            services.AddAuthorization();

            //services.AddOData();

            return services;
        }

    }
}

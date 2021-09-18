using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Handlers.Documents;
using Api.Middleware;
using FluentValidation.AspNetCore;
using Application.Extensions;
using Api.Extensions.AddServices;


namespace Api.Extensions
{
    public static class AddServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddFluentValidation();

            services.AddSwagger();

            services.AddCORS();

            services.AddHouseDbContext(Configuration);

            services.AddMediatR(typeof(CosmosGetDocumentListHandler).Assembly);

            services.AddApplication(Configuration);

            services.AddScoped<ExceptionMiddleware>();

            services.AddVersioning();
          

            return services;
        }

    }
}

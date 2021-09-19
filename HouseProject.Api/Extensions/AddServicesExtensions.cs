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

            //services.AddCORS();

            services.AddHouseDbContext(Configuration);

            services.AddCosmos(Configuration);

            services.AddApplication(Configuration);

            services.AddMediatR(typeof(GetDocumentListHandler).Assembly);

            services.AddScoped<ExceptionMiddleware>();

            services.AddVersioning();
          

            return services;
        }

    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Handlers.Documents;
using Api.Middleware;
using FluentValidation.AspNetCore;
using Application.Extensions;
using Api.Extensions.AddServices;
using Infrastructure.Extensions;
using Microsoft.AspNet.OData.Extensions;

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

            services.AddFluentValidation();

            services.AddSwagger();

            //services.AddCORS();


            services.AddInfrastructure(Configuration);
          
            services.AddApplication(Configuration);
                        
            services.AddMediatR(typeof(GetDocumentListHandler).Assembly);

            services.AddScoped<ExceptionMiddleware>();

            services.AddVersioning();

            //services.AddOData();

            return services;
        }

    }
}

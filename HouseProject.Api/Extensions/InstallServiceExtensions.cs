using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MediatR;
using Application.Handlers.Documents;
using Api.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Application.Extensions;
using Infrastructure.Persistence;

namespace Api.Extensions
{
    public static class InstallServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HouseProject", Version = "v1" });
            });
            services.AddDbContext<HouseProjectDbContext>();
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            services.AddMediatR(typeof(GetDocumentListHandler).Assembly);

            services.AddApplicationService(Configuration);

            services.AddScoped<ExceptionMiddleware>();


            services.AddApiVersioning(x => 
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            return services;
        }

        private static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration Configuration)
        {
            return ApplicationServiceExtension.AddApplication(services, Configuration);
        }
    }
}

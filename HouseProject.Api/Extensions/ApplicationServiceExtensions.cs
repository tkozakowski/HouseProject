using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MediatR;
using HouseProject.Application.Core;
using HouseProject.Application.Handlers.Documents;
using HouseProject.Application.Validators;
using HouseProject.Application.Dto;
using FluentValidation;
using HouseProject.Api.Middleware;
using FluentValidation.AspNetCore;
using HouseProject.Persistence;
using System.Reflection;

namespace HouseProject.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration Configuration)
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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<DocumentDto>, DocumentDtoValidator>();
            services.AddScoped<ExceptionMiddleware>();


            return services;
        }
    }
}

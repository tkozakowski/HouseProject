using FluentValidation;
using Application.Dto;
using Application.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services;
using Application.Interfaces;

namespace Application.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IODataMaterialService, ODataMaterialService>();
            services.AddScoped<IValidator<DocumentDto>, DocumentDtoValidator>();
            services.AddScoped<UserResolverService>();
            return services;
        }
    }
}

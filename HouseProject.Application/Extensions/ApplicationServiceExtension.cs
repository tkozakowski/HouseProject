using FluentValidation;
using HouseProject.Application.Dto;
using HouseProject.Application.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HouseProject.Application.Extensions
{
    public class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplication(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<DocumentDto>, DocumentDtoValidator>();
            return services;
        }
    }
}

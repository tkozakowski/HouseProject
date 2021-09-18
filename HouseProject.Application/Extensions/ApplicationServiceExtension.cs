using FluentValidation;
using Application.Dto;
using Application.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
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

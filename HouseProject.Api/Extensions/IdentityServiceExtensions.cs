using HouseProject.Application.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HouseProject.Api.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            var authenticationSettings = new AuthenticationSettings();
            services.AddSingleton(authenticationSettings);
            configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "Bearer";
                opt.DefaultScheme = "Bearer";
                opt.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg => {
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });


            //services.AddAuthorization(cfg => 
            //{
            //    cfg.AddPolicy
            //});



            return services;
        }
    }
}

using HouseProject.Application.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace HouseProject.Api.Middleware
{
    public class ExceptionMiddleware: IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var response = _env.IsDevelopment()
                                    ? new AppException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                                    : new AppException(context.Response.StatusCode, "Server error");

                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}

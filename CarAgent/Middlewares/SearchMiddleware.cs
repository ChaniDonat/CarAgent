
using BuisnessLogic.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CarAgent.middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SearchMiddleware
    {
        private readonly RequestDelegate _next;
        ILogger logger;

        public SearchMiddleware(RequestDelegate next, ILogger<SearchMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICarService carService)
        {
            await _next(httpContext);
            if (httpContext.Response.StatusCode == 204 || httpContext.Response.StatusCode == 404)
                //httpContext.Request.Path.Value
                await carService.AddSearchLogging(httpContext.Request.QueryString.Value);
            logger.LogError("===============================================!!!!1==========" + httpContext.Request.QueryString.Value);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSearchMiddleware(this IApplicationBuilder builder)
        {
            builder.UseWhen(context => context.Request.Path.StartsWithSegments("/api/Car/get"), b => {
                builder.UseMiddleware<SearchMiddleware>();
            });
            return builder;
        }
    }
}

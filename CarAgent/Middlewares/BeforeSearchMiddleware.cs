using BuisnessLogic.Service;
using CarAgent.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CarAgent.Middlewares
{
    public class BeforeSearchMiddleware
    {
        private readonly RequestDelegate _next;

        public BeforeSearchMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ICarService carService)
        {
            await _next(httpContext);
            await carService.AddSearchLogging(httpContext.Request.Path.Value);
        }
    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseBeforeSearchMiddleware(this IApplicationBuilder builder)
        {
            builder.UseWhen(context => context.Request.Path.StartsWithSegments("/api/Car/Get"), b => {
                builder.UseMiddleware<BeforeSearchMiddleware>();
            });
            return builder;
        }
    }
}


using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace lesson2.Middlewares
{
    public class CounterMiddleware
    {
        private readonly RequestDelegate _next;

        static int count;
        public static int Count => count;

        public CounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            count++;
            httpContext.Items["CurrentCounts"] = count;
            return _next(httpContext);
        }
    }

    public static class CounterMiddlewareExtensions
    {
        public static IApplicationBuilder UseCounterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CounterMiddleware>();
        }
    }
}

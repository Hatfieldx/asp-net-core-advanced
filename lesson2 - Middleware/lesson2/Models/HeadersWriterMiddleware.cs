using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace lesson2.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HeadersWriterMiddleware
    {
        private readonly RequestDelegate _next;

        public HeadersWriterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            foreach (var item in httpContext.Request.Headers)
                Debug.WriteLine($"Header: name: {item.Key} value: {item.Value}");

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HeadersWriterMiddlewareExtensions
    {
        public static IApplicationBuilder UseHeadersWriterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeadersWriterMiddleware>();
        }
    }
}

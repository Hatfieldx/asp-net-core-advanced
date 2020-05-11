using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace lesson2.Middlewares
{
    public class QuerySaverMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string path;

        public QuerySaverMiddleware(RequestDelegate next, string path)
        {
            _next = next;
            this.path = path;

            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {               
                using (StreamWriter sw = new StreamWriter(file.FullName, false))
                {
                    sw.WriteLine();
                }
            }
        }

        public Task Invoke(HttpContext httpContext)
        {
            var query = $"path base {httpContext.Request.PathBase.Value}; path {httpContext.Request.Path.Value}";

            using (var sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(query);
            }

            return _next(httpContext);
        }
    }

    public static class QuerySaverMiddlewareExtensions
    {
        public static IApplicationBuilder UseQuerySaverMiddleware(this IApplicationBuilder builder, string path)
        {
            return builder.UseMiddleware<QuerySaverMiddleware>(path);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<RequestLoggingMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            finally
            {
                if (httpContext.Request.Path.Value.Contains("/Actors"))
                {
                    logger.LogInformation("Request {method} {url}",
                    httpContext.Request.Method,
                    httpContext.Request.Path.Value);
                }
            }
        }
    }
}

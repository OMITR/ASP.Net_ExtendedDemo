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
            logger.LogTrace($"Request: {httpContext.Request.Path} Method: {httpContext.Request.Method}");
            await _next(httpContext);
        }

    }
}

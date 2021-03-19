using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareLogging.Middlewares
{
    public static class MiddlewareLoggerExtensions
    {
        public static IApplicationBuilder UseMiddlewareLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareLogger>();
        }
    }
}

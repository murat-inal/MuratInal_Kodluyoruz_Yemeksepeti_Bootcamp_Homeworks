using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WhiteList.Middleware
{
    public class IPControlMiddleware
    {
        private readonly RequestDelegate _next;
        IConfiguration _configuration;

        public IPControlMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();

            var IP1 = _configuration.GetSection("WhiteList:FirstIP").AsEnumerable().Where(ip => !string.IsNullOrWhiteSpace(ip.Value)).Select(ip => ip.Value).ToString();
            var IP2 = _configuration.GetSection("WhiteList:SecondIP").AsEnumerable().Where(ip => !string.IsNullOrWhiteSpace(ip.Value)).Select(ip => ip.Value).ToString();
            var requestPath = httpContext.Request.Path.Value;

            if (ipAddress == IP1)
            {
                if (requestPath.Equals("/api/home"))
                {
                    await _next.Invoke(httpContext);
                }
                else if (requestPath.Equals("/api/customer"))
                {
                    await _next.Invoke(httpContext);
                }
            }

            else if (ipAddress == IP2)
            {
                if (requestPath.Equals("/api/person"))
                {
                    await _next.Invoke(httpContext);
                }
            }

            throw new HttpListenerException(403, "This IP is not authorized to access.");
        }
    }
}

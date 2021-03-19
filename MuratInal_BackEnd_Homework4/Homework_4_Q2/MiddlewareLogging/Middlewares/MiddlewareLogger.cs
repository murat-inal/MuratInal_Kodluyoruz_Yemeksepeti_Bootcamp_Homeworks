using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLogging.Middlewares
{
    public class MiddlewareLogger
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private FileStream request;
        private const string requestPath = @"C:\Users\Murat\Desktop\Kodluyoruz Full Stack Bootcamp\Homeworks\4\Homework4-MuratInal\Homework_4_Q2\MiddlewareLogging\Middlewares\Request.txt";

        private FileStream response;
        private const string responsePath = @"C:\Users\Murat\Desktop\Kodluyoruz Full Stack Bootcamp\Homeworks\4\Homework4-MuratInal\Homework_4_Q2\MiddlewareLogging\Middlewares\Response.txt";

        public MiddlewareLogger(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<MiddlewareLogger>();
            request = File.Open(requestPath, FileMode.Append);
            response = File.Open(responsePath, FileMode.Append);
        }

        public async Task Invoke(HttpContext context)
        {
            var requestText = await RequestFormat(context.Request);
            request.Write(Encoding.UTF8.GetBytes(requestText));
            request.Flush();

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);
                var responseText = await ResponseFormat(context.Response);
                response.Write(Encoding.UTF8.GetBytes(responseText));
                response.Flush();
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        public static async Task<string> RequestFormat(HttpRequest httpRequest)
        {
            httpRequest.EnableBuffering();
            var body = httpRequest.Body;

            var buffer = new byte[Convert.ToInt32(httpRequest.ContentLength)];
            await httpRequest.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            httpRequest.Body = body;

            return $"Scheme : {httpRequest.Scheme} {Environment.NewLine}" +
                   $"Host : {httpRequest.Host} {Environment.NewLine}" +
                   $"Path : {httpRequest.Path} {Environment.NewLine}" +
                   $"Request Time : {DateTimeOffset.Now} {Environment.NewLine}" +
                   $" ------------------------------------------------------------------------------------ " +
                   $"{Environment.NewLine}{bodyAsText}";
        }

        public static async Task<string> ResponseFormat(HttpResponse httpResponse)
        {
            httpResponse.Body.Seek(0, SeekOrigin.Begin);
            string text = await new StreamReader(httpResponse.Body).ReadToEndAsync();
            httpResponse.Body.Seek(0, SeekOrigin.Begin);

            return $"Status Code :{httpResponse.StatusCode} {Environment.NewLine}" +
                   $"Response Time :{DateTimeOffset.Now} {Environment.NewLine}" +
                   $" ------------------------------------------------------------------------------------ " +
                   $"{Environment.NewLine}{text}";
        }
    }
}


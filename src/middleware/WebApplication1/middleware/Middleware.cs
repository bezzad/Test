using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApplication1.middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Invoke middleware");
            var request = httpContext.Request;
            var response = httpContext.Response;
            try
            {

                using var buffer = new MemoryStream();

                var stream = response.Body;
                response.Body = buffer;

                await _next(httpContext);

                Debug.WriteLine($"Request content type:  {httpContext.Request.Headers["Accept"]} {System.Environment.NewLine} Request path: {request.Path} {System.Environment.NewLine} Response type: {response.ContentType} {System.Environment.NewLine} Response length: {response.ContentLength ?? buffer.Length}");
                buffer.Position = 0;

                await buffer.CopyToAsync(stream);
                _logger.LogInformation("Finish Invoke middleware");
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error in costom middleware");
                response.Redirect(String.Format("/Error", "costom middleware", ex.Message));
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.  
    public static class CustomMiddlewareExtensions  
    {
        
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}

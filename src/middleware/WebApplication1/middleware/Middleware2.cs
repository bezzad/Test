namespace WebApplication1.middleware
{
    public class Middleware2
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Middleware2> _logger;
        public Middleware2(RequestDelegate next, ILogger<Middleware2>  logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Invoke middleware2");
            var response = httpContext.Response;
            try
            {
                var y = httpContext.Request.Path.ToString();
                if (httpContext.Request.Path.ToString() == "/salam" )
                {
                    httpContext.Response.StatusCode = 403;
                    throw new Exception("403");
                }
                else
                {
                    await _next.Invoke(httpContext);
                }
                _logger.LogInformation("Finish Invoke middleware2");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error in middleware2");
                response.Redirect(String.Format("/Error", "403", ex.Message));
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.  
    public static class MiddlewareExtensions
    {

        public static IApplicationBuilder UseMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware2>();
        }
    }
}

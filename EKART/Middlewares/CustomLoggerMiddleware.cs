using Microsoft.Extensions.Logging;

namespace EKART.Middlewares
{
    public class CustomLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomLoggerMiddleware> _logger;

        public CustomLoggerMiddleware(RequestDelegate next, ILogger<CustomLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) {
            var startTime = DateTime.UtcNow;

            try
            {
                _logger.LogInformation("Request started: {Method} {Path} at {Time}", context.Request.Method, context.Request.Path, startTime);
                await _next(context);
                var duration=DateTime.UtcNow - startTime;

                _logger.LogInformation("Request finished: {Method} {Path} responded {StatusCode} in {Duration} ms", context.Request.Method, context.Request.Path, context.Response.StatusCode, duration.Milliseconds);
            }
            catch(Exception ex)
            {
                var duration = DateTime.UtcNow - startTime;
                _logger.LogInformation(ex,"Request failed: {Method} {Path} after {duration} ms", context.Request.Method, context.Request.Path, duration.Milliseconds);
                throw;
            }
        }
    }
}

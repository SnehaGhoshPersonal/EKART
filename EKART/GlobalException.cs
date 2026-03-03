using System.Text.Json;

namespace EKART
{
    public class GlobalException
    {
        private readonly RequestDelegate _next;  //It sends the request to next middleware in the pipeline
        private readonly ILogger<GlobalException> _loger;  //In log it will be logged with the category(class) name which is GlobalException. That means this log is from class GlobalException. 

        public GlobalException(RequestDelegate next, ILogger<GlobalException> loger){
            _loger = loger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)  // context holds the request
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(
                        new
                        {
                            StatusCode = 404,
                            message = e.Message
                        }
                    )
                    );
            }
        }
    }
}

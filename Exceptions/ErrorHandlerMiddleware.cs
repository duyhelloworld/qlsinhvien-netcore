
using System.Text.Json;
using qlsinhvien.Exceptions;

namespace qlsinhvien.Entities;

public class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var errorResult = new ErrorResult ()
            {
                ErrorId = Guid.NewGuid().ToString(),
                StatusCode = StatusCodes.Status503ServiceUnavailable,
            };
            if (e is ServiceException httpE)
            {
                errorResult.StatusCode = httpE.StatusCode;
                errorResult.ExceptionMessage = httpE.Message;
            }
            var response = context.Response;
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = errorResult.StatusCode;
                await response.WriteAsync(JsonSerializer.Serialize(errorResult));
            }
        }   
    }
}
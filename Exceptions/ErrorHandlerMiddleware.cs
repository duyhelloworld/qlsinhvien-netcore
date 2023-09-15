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
            if (e is ServiceException httpE)
            {
                var response = context.Response;
                if (!response.HasStarted)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = httpE.MaHttp;
                    await response.WriteAsync(JsonSerializer.Serialize(new {
                        httpE.NguyenNhan,
                        httpE.DeXuatGiaiQuyet,
                        httpE.DataCanSua,
                    }));
                }
            }
            throw;
        }   
    }
}
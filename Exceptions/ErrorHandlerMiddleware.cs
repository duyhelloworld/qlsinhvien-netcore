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
        catch (ServiceException e)
        {
            var response = context.Response;
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = (int) e.MaHttp;
                await response.WriteAsync(JsonSerializer.Serialize(new
                {
                    e.NguyenNhan,
                    e.DeXuatGiaiQuyet,
                    e.DataCanSua,
                }));
            }
        }   
        catch (Exception e)
        {
            var response = context.Response;
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status500InternalServerError;
                await response.WriteAsync(JsonSerializer.Serialize(new
                {
                    NguyenNhan = "Lỗi hệ thống",
                    DeXuatGiaiQuyet = "Liên hệ với quản trị viên: 0987654321 hoặc email: googlerattot@gmail.com",
                    DataCanSua = "",
                }));
                Console.WriteLine(@$"Unhandled Exception :\n
                            - Message : {e.Message}\n
                            - StackTrace : {e.StackTrace}\n
                            - InnerException : {e.InnerException}\n
                            - Source : {e.Source}\n");
            }
        }
    }
}
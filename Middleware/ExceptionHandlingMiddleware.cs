using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Threading.Tasks;
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Tiếp tục chuỗi xử lý
            await _next(context);
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23505")
        {
            // Kiểm tra lỗi vi phạm UNIQUE constraint
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            await context.Response.WriteAsJsonAsync(new { message = "Dữ liệu đã tồn tại. Vui lòng kiểm tra lại." });
        }
        catch (Exception ex)
        {
            // Bắt lỗi chung và trả về thông báo lỗi
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { message = "Đã xảy ra lỗi. Vui lòng thử lại sau.", details = ex.Message });
        }
    }
}

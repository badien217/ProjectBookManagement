using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
        // GetStatusCode 
        // kiểm tra trạng thái code
        // bằng cách sử dụng switch 
        // nếu badrequest,notfound,Validation thì sẽ trả về trang thái code đó

        
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            // Lấy mã trạng thái HTTP từ ngoại lệ
            int statusCode = GetStatusCode(exception);
            // Đặt kiểu nội dung của phản hồi là "application/json"
            httpContext.Response.ContentType = "application/json";
            // Đặt mã trạng thái của phản hồi
            httpContext.Response.StatusCode = statusCode;

            // Nếu ngoại lệ là loại ValidationException
            if (exception.GetType() == typeof(ValidationException))
                return httpContext.Response.WriteAsync(new ExceptionModal
                {
                    // Lấy danh sách lỗi từ ValidationException và chuyển thành chuỗi
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                    // Đặt mã trạng thái là 400 (Bad Request)
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());

            // Tạo danh sách lỗi mặc định
            List<string> errors = new()
    {
        $"ERROR : {exception.Message}"
    };

            // Ghi danh sách lỗi vào phản hồi
            return httpContext.Response.WriteAsync(new ExceptionModal
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());
        }
        private static int GetStatusCode(Exception exception) =>
           exception switch
           {
               BadRequestException => StatusCodes.Status400BadRequest,
               NotFoundException => StatusCodes.Status400BadRequest,
               ValidationException => StatusCodes.Status422UnprocessableEntity,
               _ => StatusCodes.Status500InternalServerError
           };

    }
}

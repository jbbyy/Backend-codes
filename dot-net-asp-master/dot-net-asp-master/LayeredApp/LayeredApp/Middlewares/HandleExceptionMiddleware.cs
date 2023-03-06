using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using LayeredApp.Exceptions;

namespace LayeredApp.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HandleExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //always invoked when request passes through the controller
            try
            {
                await _next(httpContext);
                    //will try to redirect request to next avaliable middleware if there isnt any exceptions
            }
            catch(Exception e)
            {
                await HandleException(httpContext, e);
                //will catch any exceptions 
                //HandleException is defined ourselves below
            }
        }
        async Task HandleException(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var message = exception.Message;

            response.ContentType = "application/json";
            //always sending a json data from rest API
            await response.WriteAsync(message);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HandleExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHandleExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleExceptionMiddleware>();
        }
    }
}

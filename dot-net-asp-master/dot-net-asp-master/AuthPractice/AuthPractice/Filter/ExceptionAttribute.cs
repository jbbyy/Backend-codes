using AuthPractice.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.CompilerServices;

namespace AuthPractice.Filter
{
    public class ExceptionAttribute : ExceptionFilterAttribute
         
    {
        public override void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;
            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UserNotFoundException)){
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(UserAlreadyExistException))
                {
                context.Result= new ConflictObjectResult(message);
            }
            else
            {
                context.Result = new BadRequestObjectResult("something went wrong");
            }
        }
    }
}

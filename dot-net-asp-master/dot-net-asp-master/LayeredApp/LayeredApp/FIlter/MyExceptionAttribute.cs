
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LayeredApp.Exceptions;

namespace LayeredApp.FIlter
{
    public class MyExceptionAttribute : ExceptionFilterAttribute
        //inherit ExceptionFIlterAttribute class
    {
        //override this method from ExceptionFilterAttribute
        public override void OnException(ExceptionContext context)
        {
            var message = context.Exception.Message;
            //get message of exception that occurred 

            var exceptionType = context.Exception.GetType();
            //get type of exception eg: customerNotFound, divideByZero etc 

            if(exceptionType == typeof(CustNotFoundException))
            {
                context.Result = new NotFoundObjectResult(message);
            }
            else if (exceptionType == typeof(CustAlreadyExistException))
            {
                context.Result = new ConflictObjectResult(message); 

            }
            else
            {
                context.Result = new BadRequestObjectResult("something went wrong");
            }

        }
    }
}

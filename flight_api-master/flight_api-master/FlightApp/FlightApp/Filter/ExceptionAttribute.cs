using FlightApp.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Filter
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
       
            public override void OnException(ExceptionContext context)
            {
                var message = context.Exception.Message;
                var type = context.Exception.GetType();

                if (type == typeof(FlightAlreadyExist))
                {
                    context.Result = new ConflictObjectResult("Flight number already exist");
                }
                else if (type == typeof(NotFoundException))
                {
                    context.Result = new NotFoundObjectResult("Unable to find Flight ");
                }
                else
                {
                    context.Result = new BadRequestObjectResult("Something went wrong");
                }
            }
        }
    
}

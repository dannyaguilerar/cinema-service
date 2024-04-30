using Cinema.Core.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Api.Filters;

public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is UnauthorizedAccessException unauthorizedAccessException)
        {
            context.Result = new ObjectResult(unauthorizedAccessException.Message)
            {
                StatusCode = 401
            };
            context.ExceptionHandled = true;
        }
        else if (context.Exception is InvalidRequestException invalidModelException)
        {
            context.Result = new ObjectResult(invalidModelException.Message)
            {
                StatusCode = 400,
            };
            context.ExceptionHandled = true;
        }
        else if (context.Exception is DuplicateValueException duplicateValueException)
        {
            context.Result = new ObjectResult(duplicateValueException.Message)
            {
                StatusCode = 409,
            };
            context.ExceptionHandled = true;
        }
    }
}

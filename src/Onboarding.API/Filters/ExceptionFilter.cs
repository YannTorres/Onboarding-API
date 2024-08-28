using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Onboarding.Communication.Response;
using Onboarding.Exception.ExceptionBase;

namespace Onboarding.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is OnboardingException)
        {
            HandleProjectException(context);
        } else
        {
            ThrowUnknownError(context);
        }
    }
    private static void HandleProjectException(ExceptionContext context)
    {
        var cashFlowException = context.Exception as OnboardingException;
        var errorResponse = new ResponseErrorJson(cashFlowException!.GetErros());

        context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }
    private static void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("Unknown Error.");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}

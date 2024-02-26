using LearnASkill.Exeptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LearnASkill.Midlewares;

internal sealed class GLobalExeptionHandler : IExceptionHandler
{
    public GLobalExeptionHandler()
    {
        
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionMessage = exception.Message;

        switch (exception)
        {
            case NotFoundException:
                {
                    var notFoundProblemDetails = new ProblemDetails
                    {
                        Title = "The specified resource was not found!",
                        Status = StatusCodes.Status404NotFound,
                        Detail = exceptionMessage,
                        Instance = $"urn:myorganization:error:{Guid.NewGuid()}"
                    };

                    httpContext.Response.StatusCode = notFoundProblemDetails.Status.Value;
                    await httpContext.Response.WriteAsJsonAsync(
                        notFoundProblemDetails, cancellationToken);
                    return true;
                }
            case ValidationException:
                {
                    var validationProblemDetails = new ValidationProblemDetails
                    {
                        Title = "There are validation errors!",
                        Status = StatusCodes.Status422UnprocessableEntity,
                        Detail = exceptionMessage,
                        Instance = $"urn:myorganization:error:{Guid.NewGuid()}"
                    };

                    httpContext.Response.StatusCode = validationProblemDetails.Status.Value;
                    await httpContext.Response.WriteAsJsonAsync(
                        validationProblemDetails, cancellationToken);
                    return true;
                }
            default:
                {
                    var problemDetails = new ProblemDetails
                    {
                        Title = "An unexpected error occurred!",
                        Status = StatusCodes.Status500InternalServerError,
                        Detail = exceptionMessage,
                        Instance = $"urn:myorganization:error:{Guid.NewGuid()}"
                    };

                    httpContext.Response.StatusCode = problemDetails.Status.Value;
                    await httpContext.Response.WriteAsJsonAsync(
                        problemDetails, cancellationToken);
                    return true;
                }
        }
    }
}

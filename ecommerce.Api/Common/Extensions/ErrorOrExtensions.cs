using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Common.Extensions;

public static class ErrorOrExtensions
{
    public static IResult ToProblemDetails(this List<Error> errors)
    {
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            var validationErrors = errors
                .GroupBy(e => e.Code)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(e => e.Description).ToArray()
                );

            var validationProblemDetails = new ValidationProblemDetails(validationErrors)
            {
                Title = "Validation failed",
                Status = StatusCodes.Status400BadRequest,
            };

            return Results.ValidationProblem(validationProblemDetails.Errors);
        }

        var firstError = errors[0];

        var problemDetails = new ProblemDetails
        {
            Title = firstError.Description,
            Status = MapStatusCode(firstError.Type)
        };

        return Results.Problem(
            title: problemDetails.Title,
            statusCode: problemDetails.Status,
            detail: problemDetails.Detail);
    }

    private static int MapStatusCode(ErrorType type) => type switch
    {
        ErrorType.Conflict => StatusCodes.Status409Conflict,
        ErrorType.Validation => StatusCodes.Status400BadRequest,
        ErrorType.NotFound => StatusCodes.Status404NotFound,
        _ => StatusCodes.Status500InternalServerError
    };
}
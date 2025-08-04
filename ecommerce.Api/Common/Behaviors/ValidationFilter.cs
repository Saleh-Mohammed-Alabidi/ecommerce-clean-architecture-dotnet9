
using FluentValidation;

namespace ecommerce.Common.Behaviors;

public class ValidationFilter<TRequest> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        // Get the validator from DI
        var validator = context.HttpContext.RequestServices.GetService<IValidator<TRequest>>();
        
        if (validator is null)
        {
            // No validator found, so skip validation
            return await next(context);
        }

        // Find the request object in the arguments
        var request = context.Arguments
            .OfType<TRequest>()
            .FirstOrDefault();

        if (request is null)
        {
            return Results.BadRequest("Request object not found.");
        }

        // Perform validation
        var validationResult = await validator.ValidateAsync(request);
        
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(new
            {
                Errors = validationResult.Errors.Select(e => 
                    new { e.PropertyName, e.ErrorMessage }
                ).ToList()
            });
        }

        // If validation passes, proceed to the endpoint handler
        return await next(context);
    }
}
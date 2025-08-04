using FluentValidation;

namespace ecommerce.Api.Features.Cities.Create;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(100);
    }
}
using FluentValidation;

namespace ecommerce.Api.Features.Cities.Get;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .LessThanOrEqualTo(100);
    }
}
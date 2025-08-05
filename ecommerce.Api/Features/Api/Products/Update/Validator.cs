using FluentValidation;

namespace ecommerce.Api.Features.Products.Update;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);

        RuleFor(x => x.CategoryId).GreaterThan(0);
    }
}
using FluentValidation;

namespace ecommerce.Api.Features.Products.Delete;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
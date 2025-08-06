using FluentValidation;

namespace ecommerce.Api.Features.Products.GetById;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
using ecommerce.Common.Configuration.Constrain;
using FluentValidation;

public class RateLimitConstrainsValidator : AbstractValidator<RateLimitConstrain>
{
    public RateLimitConstrainsValidator()
    {
        RuleFor(x => x.PermitLimit)
            .NotEmpty().WithMessage("PermitLimit is required.");

        RuleFor(x => x.TimeSpan)
            .NotEmpty().WithMessage("TimeSpan is required.");

        RuleFor(x => x.QueueLimit)
            .NotEmpty().WithMessage("QueueLimit is required.");
    }
}
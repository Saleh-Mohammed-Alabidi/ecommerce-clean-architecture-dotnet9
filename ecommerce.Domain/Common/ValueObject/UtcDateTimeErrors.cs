using ErrorOr;

namespace ecommerce.Domain.Common;

public static class UtcDateTimeErrors
{
    public static readonly Error MustBeUtc = Error.Validation(
        code: "UtcDateTime.MustBeUtc",
        description: "The DateTime must be in UTC format.");
}
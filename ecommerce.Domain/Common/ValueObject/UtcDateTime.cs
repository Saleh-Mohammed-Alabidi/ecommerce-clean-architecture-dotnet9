using ErrorOr;

namespace ecommerce.Domain.Common;

public sealed class UtcDateTime : ValueObject
{
    public DateTime Value { get; }

    private UtcDateTime(DateTime value) => Value = value;

    public static ErrorOr<UtcDateTime> TryCreate(DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Utc)
            return UtcDateTimeErrors.MustBeUtc;

        return new UtcDateTime(dateTime);
    }

    public static implicit operator DateTime(UtcDateTime utcDateTime) => utcDateTime.Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString() => Value.ToString("o");
}
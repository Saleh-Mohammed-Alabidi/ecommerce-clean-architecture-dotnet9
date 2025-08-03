namespace ecommerce.Domain.Common;

public abstract class Entity<T>
{
    public T Id { get; protected set; }

    protected Entity(T id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        var other = (Entity<T>)obj;

        return EqualityComparer<T>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }

    public static bool operator ==(Entity<T> left, Entity<T> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<T> left, Entity<T> right)
    {
        return !Equals(left, right);
    }
}
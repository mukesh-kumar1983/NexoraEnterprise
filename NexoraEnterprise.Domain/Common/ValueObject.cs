namespace NexoraEnterprise.Domain.Common;

/// <summary>
/// Represents a value object in the domain.
/// </summary>
/// <remarks>
/// Value objects are compared by the values of their properties rather than by identity.
/// They are immutable(Cannot be changed after creation) and do not have an identifier.
/// </remarks>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Returns the components that participate in equality comparison.
    /// </summary>
    /// <returns>The equality components.</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return Equals(obj as ValueObject);
    }

    /// <inheritdoc />
    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();

        foreach (var component in GetEqualityComponents())
        {
            hash.Add(component);
        }

        return hash.ToHashCode();
    }

    /// <summary>
    /// Determines whether two value objects are equal.
    /// </summary>
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return EqualityComparer<ValueObject>.Default.Equals(left, right);
    }

    /// <summary>
    /// Determines whether two value objects are not equal.
    /// </summary>
    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns the string representation of the value object.
    /// </summary>
    public override string ToString()
    {
        return $"{GetType().Name}";
    }
}
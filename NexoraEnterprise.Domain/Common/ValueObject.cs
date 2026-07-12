
// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Common
// File    : ValueObject.cs
// -----------------------------------------------------------------------------
//
// Represents the base class for all value objects in the domain model.
// Value objects are compared by the values of their properties rather
// than by identity.
//
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Common;

/// <summary>
/// Represents the base class for all value objects.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Returns the collection of values that participate in equality.
    /// </summary>
    /// <returns>
    /// A sequence of values used for equality comparison.
    /// </returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as ValueObject);
    }

    /// <inheritdoc/>
    public bool Equals(ValueObject? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        HashCode hash = new();

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
        => Equals(left, right);

    /// <summary>
    /// Determines whether two value objects are not equal.
    /// </summary>
    public static bool operator !=(ValueObject? left, ValueObject? right)
        => !(left == right);
}

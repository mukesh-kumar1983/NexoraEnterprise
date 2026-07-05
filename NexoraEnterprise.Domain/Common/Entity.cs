using System.Diagnostics.CodeAnalysis;

namespace NexoraEnterprise.Domain.Common;

/// <summary>
/// Represents the base class for all entities within the domain.
/// </summary>
/// <remarks>
/// An entity is uniquely identified by its <see cref="Id"/> rather than
/// by the values of its properties.
/// </remarks>
public abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// A Version 7 GUID is generated automatically.
    /// </summary>
    protected Entity()
    {
        Id = Guid.CreateVersion7();
    }

    protected Entity(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; protected init; }

    /// <summary>
    /// Determines whether this entity is transient.
    /// </summary>
    public bool IsTransient => Id == default;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    /// <inheritdoc />
    public bool Equals(Entity? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (IsTransient || other.IsTransient)
            return false;

        return Id == other.Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }

    /// <summary>
    /// Determines whether two entities are equal.
    /// </summary>
    public static bool operator ==(Entity? left, Entity? right)
    {
        return EqualityComparer<Entity>.Default.Equals(left, right);
    }

    /// <summary>
    /// Determines whether two entities are not equal.
    /// </summary>
    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns the string representation of the entity.
    /// </summary>
    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}
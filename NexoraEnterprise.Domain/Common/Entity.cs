// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Common
// File    : Entity.cs
// -----------------------------------------------------------------------------
// <copyright>
// Copyright (c) NexoraEnterprise.
// </copyright>
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Common;

/// <summary>
/// Represents the base class for all domain entities.
/// </summary>
/// <typeparam name="TId">The type of the entity identifier.</typeparam>
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    /// <summary>
    /// Gets the unique identifier of the entity.
    /// </summary>
    public TId Id { get; protected set; } = default!;

    /// <summary>
    /// Determines whether the entity has not yet been assigned an identifier.
    /// </summary>
    public bool IsTransient()
        => EqualityComparer<TId>.Default.Equals(Id, default!);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => Equals(obj as Entity<TId>);

    /// <inheritdoc/>
    public bool Equals(Entity<TId>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetType() != other.GetType())
            return false;

        if (IsTransient() || other.IsTransient())
            return false;

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
        => IsTransient()
            ? base.GetHashCode()
            : HashCode.Combine(GetType(), Id);

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        => Equals(left, right);

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        => !(left == right);
}

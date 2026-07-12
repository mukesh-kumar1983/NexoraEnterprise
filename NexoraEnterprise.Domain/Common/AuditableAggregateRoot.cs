
// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Common
// File    : AuditableAggregateRoot.cs
// -----------------------------------------------------------------------------
//
// Represents the base class for aggregate roots that support
// auditing information and soft deletion.
//
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Common;

/// <summary>
/// Represents an aggregate root that supports auditing and soft deletion.
/// </summary>
/// <typeparam name="TId">
/// The type of the aggregate identifier.
/// </typeparam>
public abstract class AuditableAggregateRoot<TId> : AggregateRoot<TId>
    where TId : notnull
{
    /// <summary>
    /// Gets the UTC date and time when the aggregate was created.
    /// </summary>
    public DateTimeOffset CreatedOnUtc { get; protected set; }

    /// <summary>
    /// Gets the UTC date and time when the aggregate was last modified.
    /// </summary>
    public DateTimeOffset? ModifiedOnUtc { get; protected set; }

    /// <summary>
    /// Gets the UTC date and time when the aggregate was soft deleted.
    /// </summary>
    public DateTimeOffset? DeletedOnUtc { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the aggregate has been soft deleted.
    /// </summary>
    public bool IsDeleted { get; protected set; }

    /// <summary>
    /// Marks the aggregate as newly created.
    /// </summary>
    protected void MarkCreated()
    {
        CreatedOnUtc = DateTimeOffset.UtcNow;
        ModifiedOnUtc = null;
        DeletedOnUtc = null;
        IsDeleted = false;
    }

    /// <summary>
    /// Marks the aggregate as modified.
    /// </summary>
    protected void MarkModified()
    {
        ModifiedOnUtc = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Marks the aggregate as soft deleted.
    /// </summary>
    protected void MarkDeleted()
    {
        if (IsDeleted)
        {
            return;
        }

        IsDeleted = true;
        DeletedOnUtc = DateTimeOffset.UtcNow;
        MarkModified();
    }

    /// <summary>
    /// Restores a previously soft-deleted aggregate.
    /// </summary>
    protected void Restore()
    {
        IsDeleted = false;
        DeletedOnUtc = null;
        MarkModified();
    }
}

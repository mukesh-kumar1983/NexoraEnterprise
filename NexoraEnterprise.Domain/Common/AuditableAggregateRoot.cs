namespace NexoraEnterprise.Domain.Common;

/// <summary>
/// Represents an aggregate root that supports auditing and soft deletion.
/// </summary>
public abstract class AuditableAggregateRoot : AggregateRoot
{
    protected AuditableAggregateRoot()
    {
    }

    protected AuditableAggregateRoot(Guid id)
        : base(id)
    {
    }

    /// <summary>
    /// Gets the UTC date and time when the entity was created.
    /// </summary>
    public DateTimeOffset CreatedOn { get; internal set; }

    /// <summary>
    /// Gets the identifier of the user who created the entity.
    /// </summary>
    public Guid? CreatedBy { get; internal set; }

    /// <summary>
    /// Gets the UTC date and time when the entity was last modified.
    /// </summary>
    public DateTimeOffset? ModifiedOn { get; internal set; }

    /// <summary>
    /// Gets the identifier of the user who last modified the entity.
    /// </summary>
    public Guid? ModifiedBy { get; internal set; }

    /// <summary>
    /// Gets the UTC date and time when the entity was soft deleted.
    /// </summary>
    public DateTimeOffset? DeletedOn { get; internal set; }

    /// <summary>
    /// Gets the identifier of the user who soft deleted the entity.
    /// </summary>
    public Guid? DeletedBy { get; internal set; }

    /// <summary>
    /// Gets a value indicating whether the entity has been soft deleted.
    /// </summary>
    public bool IsDeleted { get; internal set; }
}
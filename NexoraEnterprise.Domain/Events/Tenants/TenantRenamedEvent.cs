using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Domain event raised when a tenant name is changed.
/// 
/// This event represents the business fact that the tenant identity
/// information has been updated.
/// </summary>
public sealed class TenantRenamedEvent : DomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantRenamedEvent"/> class.
    /// </summary>
    /// <param name="tenantId">
    /// The identifier of the tenant.
    /// </param>
    /// <param name="oldName">
    /// The previous tenant name.
    /// </param>
    /// <param name="newName">
    /// The new tenant name.
    /// </param>
    public TenantRenamedEvent(
        Guid tenantId,
        string oldName,
        string newName)
    {
        TenantId = tenantId;
        OldName = oldName;
        NewName = newName;
    }

    /// <summary>
    /// Gets the tenant identifier.
    /// </summary>
    public Guid TenantId { get; }

    /// <summary>
    /// Gets the previous tenant name.
    /// </summary>
    public string OldName { get; }

    /// <summary>
    /// Gets the new tenant name.
    /// </summary>
    public string NewName { get; }
}
using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Domain event raised when a tenant code is changed.
/// 
/// Tenant codes are used as a unique business identifier, therefore
/// any change should be captured as a domain event.
/// </summary>
public sealed class TenantCodeChangedEvent : DomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantCodeChangedEvent"/> class.
    /// </summary>
    /// <param name="tenantId">
    /// The identifier of the tenant.
    /// </param>
    /// <param name="oldCode">
    /// The previous tenant code.
    /// </param>
    /// <param name="newCode">
    /// The new tenant code.
    /// </param>
    public TenantCodeChangedEvent(
        Guid tenantId,
        string oldCode,
        string newCode)
    {
        TenantId = tenantId;
        OldCode = oldCode;
        NewCode = newCode;
    }

    /// <summary>
    /// Gets the tenant identifier.
    /// </summary>
    public Guid TenantId { get; }

    /// <summary>
    /// Gets the previous tenant code.
    /// </summary>
    public string OldCode { get; }

    /// <summary>
    /// Gets the new tenant code.
    /// </summary>
    public string NewCode { get; }
}
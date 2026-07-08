using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Domain event raised when a tenant is activated.
///
/// This event indicates that the tenant is now operational and users
/// belonging to the tenant are allowed to access the platform.
///
/// Possible subscribers:
/// <list type="bullet">
/// <item>Enable tenant access.</item>
/// <item>Activate subscription.</item>
/// <item>Write audit log.</item>
/// <item>Send activation notification.</item>
/// <item>Publish integration event.</item>
/// </list>
/// </summary>
public sealed class TenantActivatedEvent : DomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantActivatedEvent"/> class.
    /// </summary>
    /// <param name="tenantId">Unique identifier of the activated tenant.</param>
    public TenantActivatedEvent(Guid tenantId)
    {
        TenantId = tenantId;
    }

    /// <summary>
    /// Gets the unique identifier of the activated tenant.
    /// </summary>
    public Guid TenantId { get; }
}
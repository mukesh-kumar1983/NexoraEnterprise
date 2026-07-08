using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Domain event raised when a tenant is suspended.
///
/// Suspension is a temporary business state. The tenant and its data remain
/// intact, but users are prevented from accessing the system until the tenant
/// is activated again.
///
/// Possible subscribers:
/// <list type="bullet">
/// <item>Block user sign-in.</item>
/// <item>Pause scheduled background jobs.</item>
/// <item>Notify tenant administrators.</item>
/// <item>Write audit logs.</item>
/// <item>Publish integration events.</item>
/// </list>
/// </summary>
public sealed class TenantSuspendedEvent : DomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantSuspendedEvent"/> class.
    /// </summary>
    /// <param name="tenantId">Unique identifier of the suspended tenant.</param>
    public TenantSuspendedEvent(Guid tenantId)
    {
        TenantId = tenantId;
    }

    /// <summary>
    /// Gets the unique identifier of the suspended tenant.
    /// </summary>
    public Guid TenantId { get; }
}
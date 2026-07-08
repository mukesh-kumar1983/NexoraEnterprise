using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Domain event raised when a tenant is permanently deactivated.
///
/// A deactivated tenant is considered permanently closed and is no longer
/// allowed to access the platform. Unlike suspension, this is intended to
/// be a terminal business state.
///
/// Possible subscribers:
/// <list type="bullet">
/// <item>Disable all tenant users.</item>
/// <item>Cancel active subscriptions.</item>
/// <item>Archive tenant resources.</item>
/// <item>Write audit logs.</item>
/// <item>Publish integration events.</item>
/// </list>
/// </summary>
public sealed class TenantDeactivatedEvent : DomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantDeactivatedEvent"/> class.
    /// </summary>
    /// <param name="tenantId">Unique identifier of the deactivated tenant.</param>
    public TenantDeactivatedEvent(Guid tenantId)
    {
        TenantId = tenantId;
    }

    /// <summary>
    /// Gets the unique identifier of the deactivated tenant.
    /// </summary>
    public Guid TenantId { get; }
}
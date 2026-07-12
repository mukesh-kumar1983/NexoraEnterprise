using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Raised when a tenant is deleted.
/// </summary>
public sealed class TenantDeletedEvent : DomainEvent
{
    public Guid TenantId { get; }

    public TenantDeletedEvent(Guid tenantId)
    {
        TenantId = tenantId;
    }
}
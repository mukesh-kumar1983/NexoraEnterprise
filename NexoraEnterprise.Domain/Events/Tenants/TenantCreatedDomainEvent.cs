// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// File    : TenantCreatedDomainEvent.cs
// -----------------------------------------------------------------------------
using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Raised when a new tenant has been created.
/// </summary>
public sealed class TenantCreatedDomainEvent : DomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantCreatedDomainEvent"/> class.
    /// </summary>
    public TenantCreatedDomainEvent(Guid tenantId, string code, string name)
    {
        TenantId = tenantId;
        Code = code;
        Name = name;
    }

    public Guid TenantId { get; }
    public string Code { get; }
    public string Name { get; }
}

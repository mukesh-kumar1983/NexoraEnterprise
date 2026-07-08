using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Events.Tenants;

/// <summary>
/// Domain event raised when a new tenant is registered.
///
/// This event indicates that a new company has been successfully created
/// within the platform. Other parts of the system may subscribe to this
/// event to perform post-registration actions such as:
/// <list type="bullet">
/// <item>Create default roles.</item>
/// <item>Create default administrator user.</item>
/// <item>Initialize default application settings.</item>
/// <item>Provision storage resources.</item>
/// <item>Send welcome email.</item>
/// <item>Publish an integration event.</item>
/// </list>
/// </summary>
public sealed class TenantRegisteredEvent : DomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantRegisteredEvent"/> class.
    /// </summary>
    /// <param name="tenantId">The unique identifier of the registered tenant.</param>
    public TenantRegisteredEvent(Guid tenantId)
    {
        TenantId = tenantId;
    }

    /// <summary>
    /// Gets the unique identifier of the registered tenant.
    /// </summary>
    public Guid TenantId { get; }
}
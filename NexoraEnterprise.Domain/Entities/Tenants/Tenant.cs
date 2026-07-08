using NexoraEnterprise.Domain.Common;
using NexoraEnterprise.Domain.Enums;
using NexoraEnterprise.Domain.Events.Tenants;
using NexoraEnterprise.Domain.Rules.Tenants;

namespace NexoraEnterprise.Domain.Entities.Tenants;

/// <summary>
/// Represents a tenant (company) within the NexoraEnterprise platform.
///
/// A tenant is the highest business boundary in the system.
/// Every user, employee, department, branch, customer and other business
/// entities belong to exactly one tenant.
///
/// Responsibilities:
/// - Maintain tenant identity.
/// - Control tenant lifecycle.
/// - Enforce business rules.
/// - Raise domain events.
/// </summary>
public sealed class Tenant : AuditableAggregateRoot
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tenant"/> class.
    /// Required by Entity Framework Core.
    /// </summary>
    private Tenant()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Tenant"/> class.
    /// </summary>
    /// <param name="code">Unique tenant code.</param>
    /// <param name="name">Tenant name.</param>
    private Tenant(string code, string name)
    {
        CheckRule(new TenantCodeCannotBeEmptyRule(code));
        CheckRule(new TenantNameCannotBeEmptyRule(name));

        Code = NormalizeCode(code);
        Name = NormalizeName(name);

        Status = TenantStatus.Pending;
        RegisteredOn = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Gets the unique tenant code.
    /// </summary>
    public string Code { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the tenant name.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the current tenant status.
    /// </summary>
    public TenantStatus Status { get; private set; }

    /// <summary>
    /// Gets the date and time when the tenant was registered.
    /// </summary>
    public DateTimeOffset RegisteredOn { get; private set; }

    /// <summary>
    /// Registers a new tenant.
    /// </summary>
    /// <param name="code">Unique tenant code.</param>
    /// <param name="name">Tenant name.</param>
    /// <returns>A newly created tenant.</returns>
    public static Tenant Register(string code, string name)
    {
        var tenant = new Tenant(code, name);

        tenant.RaiseDomainEvent(new TenantRegisteredEvent(tenant.Id));

        return tenant;
    }

    /// <summary>
    /// Renames the tenant.
    /// </summary>
    /// <param name="name">New tenant name.</param>
    public void Rename(string name)
    {
        CheckRule(new TenantNameCannotBeEmptyRule(name));

        Name = NormalizeName(name);
    }

    /// <summary>
    /// Activates the tenant.
    /// </summary>
    public void Activate()
    {
        CheckRule(new TenantCannotBeActivatedWhenInactiveRule(Status));

        if (Status == TenantStatus.Active)
            return;

        Status = TenantStatus.Active;

        RaiseDomainEvent(new TenantActivatedEvent(Id));
    }

    /// <summary>
    /// Suspends the tenant.
    /// </summary>
    public void Suspend()
    {
        if (Status == TenantStatus.Suspended)
            return;

        Status = TenantStatus.Suspended;

        RaiseDomainEvent(new TenantSuspendedEvent(Id));
    }

    /// <summary>
    /// Permanently deactivates the tenant.
    /// </summary>
    public void Deactivate()
    {
        if (Status == TenantStatus.Inactive)
            return;

        Status = TenantStatus.Inactive;

        RaiseDomainEvent(new TenantDeactivatedEvent(Id));
    }

    /// <summary>
    /// Normalizes the tenant code.
    /// </summary>
    /// <param name="code">Tenant code.</param>
    /// <returns>Normalized tenant code.</returns>
    private static string NormalizeCode(string code)
    {
        return code.Trim().ToUpperInvariant();
    }

    /// <summary>
    /// Normalizes the tenant name.
    /// </summary>
    /// <param name="name">Tenant name.</param>
    /// <returns>Normalized tenant name.</returns>
    private static string NormalizeName(string name)
    {
        return name.Trim();
    }
}
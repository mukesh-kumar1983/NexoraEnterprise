
using NexoraEnterprise.Domain.Common;
using NexoraEnterprise.Domain.Enums;
using NexoraEnterprise.Domain.Events.Tenants;
using NexoraEnterprise.Domain.Rules.Tenants;

namespace NexoraEnterprise.Domain.Entities.Tenants;

/// <summary>
/// Represents a tenant (company) within the NexoraEnterprise platform.
/// This is Part 1 of the complete aggregate.
/// </summary>
public sealed partial class Tenant : AuditableAggregateRoot<Guid>
{
    /// <summary>
    /// Required by Entity Framework Core.
    /// </summary>
    private Tenant()
    {
    }

    /// <summary>
    /// Initializes a new tenant with the specified identifier.
    /// </summary>
    /// <param name="id">Tenant identifier.</param>
    private Tenant(Guid id)
    {
        Id = id;
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
    /// Creates a new tenant.
    /// </summary>
    public static Tenant Create(string code, string name)
    {
        var tenant = new Tenant(Guid.CreateVersion7());

        tenant.SetCode(code);
        tenant.SetName(name);

        tenant.Status = TenantStatus.Pending;

        tenant.MarkCreated();

        tenant.RaiseDomainEvent(
    new TenantCreatedDomainEvent(
        tenant.Id,
        tenant.Code,
        tenant.Name));

        return tenant;
    }

    /// <summary>
    /// Renames the tenant.
    /// </summary>
    /// <param name="name">
    /// The new tenant name.
    /// </param>
    public void Rename(string name)
    {
        var oldName = Name;

        SetName(name);

        if (oldName == Name)
        {
            return;
        }

        MarkModified();

        RaiseDomainEvent(
            new TenantRenamedEvent(
                Id,
                oldName,
                Name));
    }

    /// <summary>
    /// Changes the tenant code.
    /// </summary>
    /// <param name="code">
    /// The new tenant code.
    /// </param>
    public void ChangeCode(string code)
    {
        var oldCode = Code;

        SetCode(code);

        if (oldCode == Code)
        {
            return;
        }

        MarkModified();

        RaiseDomainEvent(
            new TenantCodeChangedEvent(
                Id,
                oldCode,
                Code));
    }

    /// <summary>
    /// Sets the tenant code.
    /// </summary>
    /// <param name="code">Tenant code.</param>
    private void SetCode(string code)
    {
        CheckRule(new TenantCodeCannotBeEmptyRule(code));

        Code = code.Trim().ToUpperInvariant();
    }

    /// <summary>
    /// Sets the tenant name.
    /// </summary>
    /// <param name="name">Tenant name.</param>
    private void SetName(string name)
    {
        CheckRule(new TenantNameCannotBeEmptyRule(name));

        Name = name.Trim();
    }
}

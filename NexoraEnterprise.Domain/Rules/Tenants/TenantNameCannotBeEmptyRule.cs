using NexoraEnterprise.Domain.Rules;

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Business rule that ensures a tenant name is provided.
/// </summary>
public sealed class TenantNameCannotBeEmptyRule : BusinessRule
{
    private readonly string _tenantName;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantNameCannotBeEmptyRule"/> class.
    /// </summary>
    /// <param name="tenantName">Tenant name to validate.</param>
    public TenantNameCannotBeEmptyRule(string tenantName)
    {
        _tenantName = tenantName;
    }

    /// <inheritdoc />
    public override bool IsBroken()
    {
        return string.IsNullOrWhiteSpace(_tenantName);
    }

    /// <inheritdoc />
    public override string Message
    {
        get => "Tenant name cannot be empty.";
    }

    /// <inheritdoc />
    public override string ErrorCode
    {
        get => "TENANT_NAME_REQUIRED";
    }
}
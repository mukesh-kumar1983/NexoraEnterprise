using NexoraEnterprise.Domain.Rules;

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Business rule that ensures a tenant code is provided.
/// </summary>
public sealed class TenantCodeCannotBeEmptyRule : BusinessRule
{
    private readonly string _tenantCode;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantCodeCannotBeEmptyRule"/> class.
    /// </summary>
    /// <param name="tenantCode">Tenant code to validate.</param>
    public TenantCodeCannotBeEmptyRule(string tenantCode)
    {
        _tenantCode = tenantCode;
    }

    /// <inheritdoc />
    public override bool IsBroken()
    {
        return string.IsNullOrWhiteSpace(_tenantCode);
    }

    /// <inheritdoc />
    public override string Message
    {
        get => "Tenant code cannot be empty.";
    }

    /// <inheritdoc />
    public override string ErrorCode
    {
        get => "TENANT_CODE_REQUIRED";
    }
}
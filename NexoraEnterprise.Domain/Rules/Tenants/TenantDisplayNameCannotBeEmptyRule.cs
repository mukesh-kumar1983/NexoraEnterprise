using NexoraEnterprise.Domain.Rules;

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Ensures that the tenant display name is provided.
/// </summary>
public sealed class TenantDisplayNameCannotBeEmptyRule : BusinessRule
{
    private readonly string _displayName;

    public TenantDisplayNameCannotBeEmptyRule(string displayName)
    {
        _displayName = displayName;
    }

    public override bool IsBroken()
        => string.IsNullOrWhiteSpace(_displayName);

    public override string Message
        => "Display name cannot be empty.";

    public override string ErrorCode
        => "TENANT_DISPLAY_NAME_REQUIRED";
}
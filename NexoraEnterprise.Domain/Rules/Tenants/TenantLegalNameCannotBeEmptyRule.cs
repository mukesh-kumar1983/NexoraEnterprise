using NexoraEnterprise.Domain.Rules;

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Ensures that the legal company name is provided.
/// </summary>
public sealed class TenantLegalNameCannotBeEmptyRule : BusinessRule
{
    private readonly string _legalName;

    public TenantLegalNameCannotBeEmptyRule(string legalName)
    {
        _legalName = legalName;
    }

    public override bool IsBroken()
        => string.IsNullOrWhiteSpace(_legalName);

    public override string Message
        => "Legal name cannot be empty.";

    public override string ErrorCode
        => "TENANT_LEGAL_NAME_REQUIRED";
}
// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Rules
// File    : TenantNameLengthRule.cs
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Ensures that the tenant name length is within the allowed range.
/// </summary>
public sealed class TenantNameLengthRule : BusinessRule
{
    private const int MinimumLength = 3;
    private const int MaximumLength = 200;

    private readonly string? _name;

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="TenantNameLengthRule"/> class.
    /// </summary>
    /// <param name="name">
    /// Tenant name.
    /// </param>
    public TenantNameLengthRule(string? name)
    {
        _name = name;
    }

    /// <inheritdoc />
    public override bool IsBroken()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            return false;
        }

        return _name.Length < MinimumLength ||
               _name.Length > MaximumLength;
    }

    /// <inheritdoc />
    public override string Message =>
        $"Tenant name must be between {MinimumLength} and {MaximumLength} characters.";

    /// <inheritdoc />
    public override string ErrorCode =>
        "TENANT_NAME_LENGTH_INVALID";
}
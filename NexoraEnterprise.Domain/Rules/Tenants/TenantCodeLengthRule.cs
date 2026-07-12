// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Rules
// File    : TenantCodeLengthRule.cs
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Ensures that the tenant code length is within the allowed range.
/// </summary>
public sealed class TenantCodeLengthRule : BusinessRule
{
    private const int MinimumLength = 3;
    private const int MaximumLength = 20;

    private readonly string? _code;

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="TenantCodeLengthRule"/> class.
    /// </summary>
    /// <param name="code">
    /// Tenant code.
    /// </param>
    public TenantCodeLengthRule(string? code)
    {
        _code = code;
    }

    /// <inheritdoc />
    public override bool IsBroken()
    {
        if (string.IsNullOrWhiteSpace(_code))
        {
            return false;
        }

        return _code.Length < MinimumLength ||
               _code.Length > MaximumLength;
    }

    /// <inheritdoc />
    public override string Message =>
        $"Tenant code must be between {MinimumLength} and {MaximumLength} characters.";

    /// <inheritdoc />
    public override string ErrorCode =>
        "TENANT_CODE_LENGTH_INVALID";
}
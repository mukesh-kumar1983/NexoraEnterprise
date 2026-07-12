// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Rules
// File    : TenantCodeFormatRule.cs
// -----------------------------------------------------------------------------

using System.Text.RegularExpressions;

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Ensures that the tenant code has a valid format.
/// </summary>
public sealed class TenantCodeFormatRule : BusinessRule
{
    private static readonly Regex Regex = new(
        @"^[A-Z][A-Z0-9-]*$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private readonly string _code;

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="TenantCodeFormatRule"/> class.
    /// </summary>
    /// <param name="code">
    /// Tenant code.
    /// </param>
    public TenantCodeFormatRule(string code)
    {
        _code = code ?? string.Empty;
    }

    /// <inheritdoc />
    public override bool IsBroken()
    {
        return !Regex.IsMatch(_code);
    }

    /// <inheritdoc />
    public override string Message =>
        "Tenant code must start with a letter and contain only uppercase letters, digits, and hyphens.";

    /// <inheritdoc />
    public override string ErrorCode =>
        "TENANT_CODE_INVALID_FORMAT";
}
// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Rules
// File    : IBusinessRule.cs
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Rules;

/// <summary>
/// Represents a business rule that must be satisfied.
/// </summary>
public interface IBusinessRule
{
    /// <summary>
    /// Returns <c>true</c> when the business rule is violated.
    /// </summary>
    bool IsBroken();

    /// <summary>
    /// Gets the validation message.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// Gets the unique error code.
    /// </summary>
    string ErrorCode { get; }
}
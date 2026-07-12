// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Rules
// File    : BusinessRule.cs
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Rules;

/// <summary>
/// Represents the base class for all business rules.
///
/// Business rules encapsulate domain invariants that must be satisfied
/// before an aggregate can change its state.
/// </summary>
public abstract class BusinessRule : IBusinessRule
{
    /// <inheritdoc />
    public abstract bool IsBroken();

    /// <inheritdoc />
    public abstract string Message { get; }

    /// <inheritdoc />
    public abstract string ErrorCode { get; }
}
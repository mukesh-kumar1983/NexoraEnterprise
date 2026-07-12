// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Rules
// File    : BusinessRuleValidationException.cs
// -----------------------------------------------------------------------------

using NexoraEnterprise.Domain.Exceptions;

namespace NexoraEnterprise.Domain.Rules;

/// <summary>
/// Exception thrown when a business rule has been violated.
/// </summary>
public sealed class BusinessRuleValidationException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="BusinessRuleValidationException"/> class.
    /// </summary>
    /// <param name="brokenRule">
    /// The violated business rule.
    /// </param>
    public BusinessRuleValidationException(
        IBusinessRule brokenRule)
        : base(brokenRule?.Message
            ?? throw new ArgumentNullException(nameof(brokenRule)))
    {
        BrokenRule = brokenRule;
    }

    /// <summary>
    /// Gets the violated business rule.
    /// </summary>
    public IBusinessRule BrokenRule { get; }
}
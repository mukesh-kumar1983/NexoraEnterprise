using NexoraEnterprise.Domain.Exceptions;

namespace NexoraEnterprise.Domain.Rules;

/// <summary>
/// The exception that is thrown when a business rule is violated.
/// </summary>
public sealed class BusinessRuleValidationException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleValidationException"/> class.
    /// </summary>
    /// <param name="brokenRule">The violated business rule.</param>
    public BusinessRuleValidationException(IBusinessRule brokenRule)
        : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
    }

    /// <summary>
    /// Gets the violated business rule.
    /// </summary>
    public IBusinessRule BrokenRule { get; }
}
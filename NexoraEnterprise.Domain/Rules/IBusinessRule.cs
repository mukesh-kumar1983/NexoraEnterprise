namespace NexoraEnterprise.Domain.Rules;

/// <summary>
/// Represents a business rule that must be satisfied.
/// </summary>
public interface IBusinessRule
{
    /// <summary>
    /// Gets a value indicating whether the rule has been broken.
    /// </summary>
    bool IsBroken();

    /// <summary>
    /// Gets the error message describing the rule violation.
    /// </summary>
    string Message { get; }
}
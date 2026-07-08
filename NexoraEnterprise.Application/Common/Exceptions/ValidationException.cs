using FluentValidation.Results;

namespace NexoraEnterprise.Application.Common.Exceptions;

/// <summary>
/// Represents an exception that occurs when one or more validation
/// failures occur within the application layer.
/// </summary>
public sealed class ValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="failures">Validation failures.</param>
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : base("One or more validation failures have occurred.")
    {
        Errors = failures
            .GroupBy(f => f.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(f => f.ErrorMessage).Distinct().ToArray());
    }

    /// <summary>
    /// Gets validation errors grouped by property name.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; }
}
using System.Collections.ObjectModel;

namespace NexoraEnterprise.Application.Common.Results;

/// <summary>
/// Represents the outcome of an operation that does not return a value.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    /// <param name="isSuccess">Indicates whether the operation succeeded.</param>
    /// <param name="errors">The collection of errors.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="errors"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the success/error combination is invalid.
    /// </exception>
    protected internal Result(
        bool isSuccess,
        IReadOnlyCollection<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);

        if (isSuccess && errors.Count > 0)
        {
            throw new ArgumentException(
                "A successful result cannot contain errors.",
                nameof(errors));
        }

        if (!isSuccess && errors.Count == 0)
        {
            throw new ArgumentException(
                "A failed result must contain at least one error.",
                nameof(errors));
        }

        IsSuccess = isSuccess;
        Errors = new ReadOnlyCollection<Error>(errors.ToList());
    }

    /// <summary>
    /// Gets a value indicating whether the operation completed successfully.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the errors associated with the operation.
    /// </summary>
    public IReadOnlyList<Error> Errors { get; }

    /// <summary>
    /// Gets the first error if one exists.
    /// </summary>
    public Error? FirstError =>
        Errors.Count == 0 ? null : Errors[0];

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    public static Result Success()
        => new(true, Array.Empty<Error>());

    /// <summary>
    /// Creates a failed result containing a single error.
    /// </summary>
    /// <param name="error">The error.</param>
    public static Result Failure(Error error)
    {
        ArgumentNullException.ThrowIfNull(error);

        return new(false, new[] { error });
    }

    /// <summary>
    /// Creates a failed result containing multiple errors.
    /// </summary>
    /// <param name="errors">The errors.</param>
    public static Result Failure(params Error[] errors)
    {
        ArgumentNullException.ThrowIfNull(errors);

        return new(false, errors);
    }

    /// <summary>
    /// Creates a failed result containing multiple errors.
    /// </summary>
    /// <param name="errors">The errors.</param>
    public static Result Failure(IEnumerable<Error> errors)
    {
        ArgumentNullException.ThrowIfNull(errors);

        return new(false, errors.ToList());
    }

    /// <summary>
    /// Creates a successful result containing a value.
    /// </summary>
    public static Result<T> Success<T>(T value)
        => new(value, true, Array.Empty<Error>());

    /// <summary>
    /// Creates a failed result containing a single error.
    /// </summary>
    public static Result<T> Failure<T>(Error error)
        => new(default, false, new[] { error });

    /// <summary>
    /// Creates a failed result containing multiple errors.
    /// </summary>
    public static Result<T> Failure<T>(params Error[] errors)
        => new(default, false, errors);

    /// <summary>
    /// Creates a failed result containing multiple errors.
    /// </summary>
    public static Result<T> Failure<T>(IEnumerable<Error> errors)
        => new(default, false, errors.ToList());
}
namespace NexoraEnterprise.Application.Common.Results;

/// <summary>
/// Represents the outcome of an operation that returns a value.
/// </summary>
/// <typeparam name="TValue">
/// The type of value returned by the operation.
/// </typeparam>
public sealed class Result<TValue> : Result
{
    private readonly TValue? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class.
    /// </summary>
    /// <param name="value">
    /// The value returned by the operation.
    /// </param>
    /// <param name="isSuccess">
    /// Indicates whether the operation succeeded.
    /// </param>
    /// <param name="errors">
    /// Collection of errors.
    /// </param>
    internal Result(
        TValue? value,
        bool isSuccess,
        IReadOnlyCollection<Error> errors)
        : base(isSuccess, errors)
    {
        _value = value;
    }

    /// <summary>
    /// Gets the value returned by the operation.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when attempting to access the value of a failed result.
    /// </exception>
    public TValue Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException(
                "A failed result does not contain a value.");

    /// <summary>
    /// Implicitly converts a value into a successful result.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    public static implicit operator Result<TValue>(TValue value)
        => Success(value);

    /// <summary>
    /// Implicitly converts an error into a failed result.
    /// </summary>
    /// <param name="error">
    /// The error.
    /// </param>
    public static implicit operator Result<TValue>(Error error)
        => Failure<TValue>(error);

    /// <summary>
    /// Implicitly converts multiple errors into a failed result.
    /// </summary>
    /// <param name="errors">
    /// The errors.
    /// </param>
    public static implicit operator Result<TValue>(Error[] errors)
        => Failure<TValue>(errors);
}
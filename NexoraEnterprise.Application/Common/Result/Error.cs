namespace NexoraEnterprise.Application.Common.Results;

/// <summary>
/// Represents an application error.
/// </summary>
public sealed record Error
{
    /// <summary>
    /// Represents the absence of an error.
    /// </summary>
    public static readonly Error None = new(
        string.Empty,
        string.Empty,
        ErrorType.None);

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> record.
    /// </summary>
    public Error(
        string code,
        string message,
        ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    /// <summary>
    /// Gets the machine-readable error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the human-readable error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the error category.
    /// </summary>
    public ErrorType Type { get; }

    /// <summary>
    /// Creates a validation error.
    /// </summary>
    public static Error Validation(
        string code,
        string message)
        => new(code, message, ErrorType.Validation);

    /// <summary>
    /// Creates a not-found error.
    /// </summary>
    public static Error NotFound(
        string code,
        string message)
        => new(code, message, ErrorType.NotFound);

    /// <summary>
    /// Creates a conflict error.
    /// </summary>
    public static Error Conflict(
        string code,
        string message)
        => new(code, message, ErrorType.Conflict);

    /// <summary>
    /// Creates an unauthorized error.
    /// </summary>
    public static Error Unauthorized(
        string code,
        string message)
        => new(code, message, ErrorType.Unauthorized);

    /// <summary>
    /// Creates a forbidden error.
    /// </summary>
    public static Error Forbidden(
        string code,
        string message)
        => new(code, message, ErrorType.Forbidden);

    /// <summary>
    /// Creates a failure error.
    /// </summary>
    public static Error Failure(
        string code,
        string message)
        => new(code, message, ErrorType.Failure);

    /// <inheritdoc />
    public override string ToString()
        => $"{Code}: {Message}";
}
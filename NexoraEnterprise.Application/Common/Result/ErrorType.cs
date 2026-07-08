namespace NexoraEnterprise.Application.Common.Results;

/// <summary>
/// Represents the category of an application error.
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// No error.
    /// </summary>
    None = 0,

    /// <summary>
    /// One or more validation rules failed.
    /// </summary>
    Validation = 1,

    /// <summary>
    /// The requested resource was not found.
    /// </summary>
    NotFound = 2,

    /// <summary>
    /// The requested operation conflicts with existing data.
    /// </summary>
    Conflict = 3,

    /// <summary>
    /// Authentication is required.
    /// </summary>
    Unauthorized = 4,

    /// <summary>
    /// The authenticated user does not have permission to perform the requested operation.
    /// </summary>
    Forbidden = 5,

    /// <summary>
    /// A business rule was violated.
    /// </summary>
    BusinessRule = 6,

    /// <summary>
    /// A general application failure occurred.
    /// </summary>
    Failure = 7,

    /// <summary>
    /// An unexpected system error occurred.
    /// </summary>
    Unexpected = 8
}
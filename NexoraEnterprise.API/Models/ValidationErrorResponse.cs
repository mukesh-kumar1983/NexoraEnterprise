namespace NexoraEnterprise.API.Models;

/// <summary>
/// Represents a standardized validation error response returned by the API.
/// </summary>
public sealed class ValidationErrorResponse : ApiErrorResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationErrorResponse"/> class.
    /// </summary>
    public ValidationErrorResponse()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationErrorResponse"/> class.
    /// </summary>
    /// <param name="statusCode">HTTP status code.</param>
    /// <param name="title">Short error title.</param>
    /// <param name="detail">Detailed error message.</param>
    /// <param name="traceId">Current request trace identifier.</param>
    /// <param name="errors">Validation errors grouped by property name.</param>
    public ValidationErrorResponse(
        int statusCode,
        string title,
        string? detail,
        string? traceId,
        IReadOnlyDictionary<string, string[]> errors)
        : base(statusCode, title, detail, traceId)
    {
        Errors = errors;
    }

    /// <summary>
    /// Gets validation errors grouped by property name.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; init; }
        = new Dictionary<string, string[]>();
}
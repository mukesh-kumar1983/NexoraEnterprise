using System.Text.Json.Serialization;

namespace NexoraEnterprise.API.Models;

/// <summary>
/// Represents a standardized API error response returned to clients.
/// </summary>
public  class ApiErrorResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorResponse"/> class.
    /// </summary>
    public ApiErrorResponse()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiErrorResponse"/> class.
    /// </summary>
    /// <param name="statusCode">HTTP status code.</param>
    /// <param name="title">Short description of the error.</param>
    /// <param name="detail">Detailed error description.</param>
    /// <param name="traceId">Current request trace identifier.</param>
    public ApiErrorResponse(
        int statusCode,
        string title,
        string? detail,
        string? traceId)
    {
        StatusCode = statusCode;
        Title = title;
        Detail = detail;
        TraceId = traceId;
        Timestamp = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// Gets or sets the HTTP status code.
    /// </summary>
    public int StatusCode { get; init; }

    /// <summary>
    /// Gets or sets the short error title.
    /// </summary>
    public string Title { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the detailed error message.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Detail { get; init; }

    /// <summary>
    /// Gets or sets the unique request trace identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TraceId { get; init; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the error occurred.
    /// </summary>
    public DateTimeOffset Timestamp { get; init; }

    /// <summary>
    /// Gets or sets additional metadata associated with the error.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IDictionary<string, object>? Extensions { get; init; }
}
namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Represents the current execution context for the request.
/// </summary>
public interface IRequestContext
{
    /// <summary>
    /// Gets the current correlation identifier.
    /// </summary>
    string CorrelationId { get; }

    /// <summary>
    /// Gets the distributed trace identifier.
    /// </summary>
    string? TraceId { get; }

    /// <summary>
    /// Gets the distributed span identifier.
    /// </summary>
    string? SpanId { get; }

    /// <summary>
    /// Gets the authenticated user's identifier.
    /// </summary>
    Guid? UserId { get; }

    /// <summary>
    /// Gets the authenticated user's name.
    /// </summary>
    string? UserName { get; }

    /// <summary>
    /// Gets the authenticated user's email.
    /// </summary>
    string? Email { get; }

    /// <summary>
    /// Gets whether the request is authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Gets the current tenant identifier.
    /// </summary>
    Guid? TenantId { get; }

    /// <summary>
    /// Gets the tenant code.
    /// </summary>
    string? TenantCode { get; }

    /// <summary>
    /// Gets the tenant name.
    /// </summary>
    string? TenantName { get; }
}
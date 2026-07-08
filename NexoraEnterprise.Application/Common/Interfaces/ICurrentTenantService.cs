namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Provides information about the current tenant resolved for the request.
/// </summary>
public interface ICurrentTenantService
{
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

    /// <summary>
    /// Gets whether a tenant has been resolved.
    /// </summary>
    bool HasTenant { get; }
}
using NexoraEnterprise.Domain.Enums;

namespace NexoraEnterprise.Application.Features.Tenants.Commands.Create;

/// <summary>
/// Represents the response returned after a tenant has been created.
/// </summary>
public sealed class CreateTenantResponse
{
    /// <summary>
    /// Gets or initializes the tenant identifier.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or initializes the tenant code.
    /// </summary>
    public string Code { get; init; } = string.Empty;

    /// <summary>
    /// Gets or initializes the tenant name.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Gets or initializes the tenant status.
    /// </summary>
    public TenantStatus Status { get; init; }

    /// <summary>
    /// Gets or initializes the registration date.
    /// </summary>
    public DateTimeOffset RegisteredOn { get; init; }
}
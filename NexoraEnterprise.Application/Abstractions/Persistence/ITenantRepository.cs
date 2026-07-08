using NexoraEnterprise.Domain.Entities.Tenants;

namespace NexoraEnterprise.Application.Abstractions.Persistence;

/// <summary>
/// Defines persistence operations for the <see cref="Tenant"/> aggregate.
///
/// One repository is maintained per aggregate root.
/// This keeps the repository focused on business operations instead of
/// exposing a generic CRUD interface.
/// </summary>
public interface ITenantRepository
{
    /// <summary>
    /// Determines whether a tenant with the specified code already exists.
    /// </summary>
    /// <param name="code">Tenant code.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// <c>true</c> if a tenant exists; otherwise <c>false</c>.
    /// </returns>
    ValueTask<bool> ExistsByCodeAsync(
        string code,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a tenant by its unique identifier.
    /// </summary>
    /// <param name="id">Tenant identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask<Tenant?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a tenant by its unique code.
    /// </summary>
    /// <param name="code">Tenant code.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask<Tenant?> GetByCodeAsync(
        string code,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new tenant.
    /// </summary>
    /// <param name="tenant">Tenant aggregate.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    ValueTask AddAsync(
        Tenant tenant,
        CancellationToken cancellationToken = default);
}
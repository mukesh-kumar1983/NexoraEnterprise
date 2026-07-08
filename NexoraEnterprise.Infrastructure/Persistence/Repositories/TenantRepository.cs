using Microsoft.EntityFrameworkCore;
using NexoraEnterprise.Application.Abstractions.Persistence;
using NexoraEnterprise.Domain.Entities.Tenants;

namespace NexoraEnterprise.Infrastructure.Persistence.Repositories;

/// <summary>
/// Entity Framework implementation of <see cref="ITenantRepository"/>.
/// </summary>
public sealed class TenantRepository : ITenantRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantRepository"/> class.
    /// </summary>
    /// <param name="dbContext">Application database context.</param>
    public TenantRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async ValueTask<bool> ExistsByCodeAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Tenant>()
            .AnyAsync(
                x => x.Code == code,
                cancellationToken);
    }

    /// <inheritdoc />
    public async ValueTask<Tenant?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Tenant>()
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }

    /// <inheritdoc />
    public async ValueTask<Tenant?> GetByCodeAsync(
        string code,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<Tenant>()
            .FirstOrDefaultAsync(
                x => x.Code == code,
                cancellationToken);
    }

    /// <inheritdoc />
    public ValueTask AddAsync(
        Tenant tenant,
        CancellationToken cancellationToken = default)
    {
        _dbContext.Set<Tenant>().Add(tenant);

        return ValueTask.CompletedTask;
    }
}
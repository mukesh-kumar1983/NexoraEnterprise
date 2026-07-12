using NexoraEnterprise.Application.Abstractions.Persistence;
using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Infrastructure.Persistence;

/// <summary>
/// Default implementation of the Unit of Work pattern.
/// </summary>
using NexoraEnterprise.Application.Common.Interfaces;



public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
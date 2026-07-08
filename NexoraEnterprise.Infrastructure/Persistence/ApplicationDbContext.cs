using Microsoft.EntityFrameworkCore;
using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Infrastructure.Persistence;

/// <summary>
/// Main EF Core database context.
/// </summary>
public sealed class ApplicationDbContext
    : DbContext, IUnitOfWork
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
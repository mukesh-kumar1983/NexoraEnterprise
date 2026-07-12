using Microsoft.EntityFrameworkCore;
using NexoraEnterprise.Application.Common.Interfaces;
using NexoraEnterprise.Domain.Common;
using NexoraEnterprise.Domain.Entities.Tenants;

namespace NexoraEnterprise.Infrastructure.Persistence;

/// <summary>
/// Main Entity Framework Core database context.
/// </summary>
public sealed class ApplicationDbContext : DbContext
{
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public DbSet<Tenant> Tenants => Set<Tenant>();

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IDomainEventDispatcher domainEventDispatcher)
        : base(options)
    {
        _domainEventDispatcher = domainEventDispatcher
            ?? throw new ArgumentNullException(nameof(domainEventDispatcher));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker
            .Entries<IDomainEventAggregate>()
            .Select(x => x.Entity)
            .SelectMany(x => x.DomainEvents)
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        if (domainEvents.Count > 0)
        {
            await _domainEventDispatcher.DispatchAsync(
                domainEvents,
                cancellationToken);

            foreach (var aggregate in ChangeTracker
                         .Entries<IDomainEventAggregate>()
                         .Select(x => x.Entity))
            {
                aggregate.ClearDomainEvents();
            }
        }

        return result;
    }
}
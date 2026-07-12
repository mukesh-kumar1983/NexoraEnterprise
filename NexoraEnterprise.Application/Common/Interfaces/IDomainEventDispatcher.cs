using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Dispatches domain events raised by aggregate roots.
/// </summary>
public interface IDomainEventDispatcher
{
    /// <summary>
    /// Dispatches the specified domain events.
    /// </summary>
    Task DispatchAsync(
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default);
}
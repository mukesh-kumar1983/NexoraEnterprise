using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Domain.Common;

public interface IDomainEventAggregate
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void ClearDomainEvents();
}
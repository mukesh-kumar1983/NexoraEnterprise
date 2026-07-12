using MediatR;
using NexoraEnterprise.Application.Common.Interfaces;
using NexoraEnterprise.Application.Common.Notifications;
using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Infrastructure.Persistence;

/// <summary>
/// Dispatches domain events using MediatR.
/// </summary>
public sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task DispatchAsync(
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in domainEvents)
        {
            var notificationType = typeof(DomainEventNotification<>)
                .MakeGenericType(domainEvent.GetType());

            var notification = Activator.CreateInstance(
                notificationType,
                domainEvent);

            if (notification is INotification mediatorNotification)
            {
                await _mediator.Publish(
                    mediatorNotification,
                    cancellationToken);
            }
        }
    }
}
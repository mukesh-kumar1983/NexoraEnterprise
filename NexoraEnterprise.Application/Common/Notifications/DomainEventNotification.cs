using MediatR;
using NexoraEnterprise.Domain.Events;

namespace NexoraEnterprise.Application.Common.Notifications;

/// <summary>
/// Wraps a domain event so it can be published through MediatR.
/// </summary>
/// <typeparam name="TDomainEvent">The domain event type.</typeparam>
public sealed class DomainEventNotification<TDomainEvent> : INotification
    where TDomainEvent : IDomainEvent
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent ?? throw new ArgumentNullException(nameof(domainEvent));
    }

    /// <summary>
    /// Gets the wrapped domain event.
    /// </summary>
    public TDomainEvent DomainEvent { get; }
}
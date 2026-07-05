namespace NexoraEnterprise.Domain.Events;

/// <summary>
/// Represents a domain event raised by an aggregate root.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the date and time when the event occurred (UTC).
    /// </summary>
    DateTimeOffset OccurredOn { get; }
}
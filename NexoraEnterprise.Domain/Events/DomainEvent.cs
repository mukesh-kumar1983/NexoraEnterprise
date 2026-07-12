
// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Events
// File    : DomainEvent.cs
// -----------------------------------------------------------------------------
//
// Base class for all domain events.
//
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Events;

/// <summary>
/// Represents the base class for all domain events.
///
/// <para>
/// Domain events capture business facts that have already occurred
/// within the domain model.
/// </para>
///
/// <para>
/// Events are raised by aggregate roots and are dispatched after the
/// current unit of work has been successfully committed.
/// </para>
/// </summary>
public abstract class DomainEvent : IDomainEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEvent"/> class.
    /// </summary>
    protected DomainEvent()
    {
        OccurredOnUtc = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets the UTC date and time when the event occurred.
    /// </summary>
    public DateTime OccurredOnUtc { get; }
}

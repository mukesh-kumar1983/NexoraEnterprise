
// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Events
// File    : IDomainEvent.cs
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Events;

/// <summary>
/// Represents a domain event raised by an aggregate root.
/// </summary>
/// <remarks>
/// Domain events capture business facts that have already occurred and
/// are dispatched after the current unit of work has completed successfully.
/// </remarks>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the UTC date and time when the domain event occurred.
    /// </summary>
    DateTime OccurredOnUtc { get; }
}

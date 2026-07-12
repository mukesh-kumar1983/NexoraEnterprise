// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Common
// File    : AggregateRoot.cs
// -----------------------------------------------------------------------------

using NexoraEnterprise.Domain.Events;
using NexoraEnterprise.Domain.Rules;

namespace NexoraEnterprise.Domain.Common;

/// <summary>
/// Represents the root of an aggregate in Domain-Driven Design (DDD).
///
/// An aggregate root is the only entry point through which external code
/// may modify an aggregate. It is responsible for enforcing business
/// invariants and raising domain events.
/// </summary>
/// <typeparam name="TId">
/// The type of the aggregate identifier.
/// </typeparam>
public abstract class AggregateRoot<TId>
    : Entity<TId>, IDomainEventAggregate
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Gets the domain events raised by this aggregate.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents =>
        _domainEvents.AsReadOnly();

    /// <summary>
    /// Raises a domain event.
    /// </summary>
    /// <param name="domainEvent">
    /// The domain event to raise.
    /// </param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);

        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Removes all pending domain events.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Verifies that the specified business rule is satisfied.
    /// </summary>
    /// <param name="rule">
    /// The business rule to evaluate.
    /// </param>
    /// <exception cref="BusinessRuleValidationException">
    /// Thrown when the business rule is violated.
    /// </exception>
    protected static void CheckRule(IBusinessRule rule)
    {
        ArgumentNullException.ThrowIfNull(rule);

        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}
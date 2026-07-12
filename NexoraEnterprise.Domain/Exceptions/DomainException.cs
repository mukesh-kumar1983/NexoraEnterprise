
// -----------------------------------------------------------------------------
// Project : NexoraEnterprise
// Layer   : Domain
// Module  : Exceptions
// File    : DomainException.cs
// -----------------------------------------------------------------------------

namespace NexoraEnterprise.Domain.Exceptions;

/// <summary>
/// Represents the base exception for the domain layer.
/// </summary>
public abstract class DomainException : Exception
{
    protected DomainException()
    {
    }

    protected DomainException(string message)
        : base(message)
    {
    }

    protected DomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

namespace NexoraEnterprise.Domain.Exceptions;

/// <summary>
/// Represents errors that occur when a domain rule is violated.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class.
    /// </summary>
    public DomainException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class
    /// with a specified error message.
    /// </summary>
    public DomainException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class
    /// with a specified error message and inner exception.
    /// </summary>
    public DomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
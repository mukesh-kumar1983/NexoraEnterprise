namespace NexoraEnterprise.Application.Common.Exceptions;

/// <summary>
/// Represents an exception that occurs when authentication
/// is required or has failed.
/// </summary>
public sealed class UnauthorizedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    public UnauthorizedException()
        : base("Authentication is required.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    public UnauthorizedException(string message)
        : base(message)
    {
    }
}
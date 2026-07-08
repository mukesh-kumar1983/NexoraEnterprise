namespace NexoraEnterprise.Application.Common.Exceptions;

/// <summary>
/// Represents an exception that occurs when the current user
/// is authenticated but is not authorized to perform the operation.
/// </summary>
public sealed class ForbiddenException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
    /// </summary>
    public ForbiddenException()
        : base("Access to the requested resource is forbidden.")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
    /// </summary>
    public ForbiddenException(string message)
        : base(message)
    {
    }
}
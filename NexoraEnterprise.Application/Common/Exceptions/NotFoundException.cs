namespace NexoraEnterprise.Application.Common.Exceptions;

/// <summary>
/// Represents an exception that occurs when a requested resource
/// cannot be found.
/// </summary>
public sealed class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    public NotFoundException(string name, object key)
        : base($"'{name}' with identifier '{key}' was not found.")
    {
    }
}
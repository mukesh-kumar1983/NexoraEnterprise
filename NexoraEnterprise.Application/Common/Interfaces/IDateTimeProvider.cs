namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Provides the current date and time in UTC.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets the current UTC date and time.
    /// </summary>
    DateTime UtcNow { get; }

    /// <summary>
    /// Gets today's UTC date.
    /// </summary>
    DateOnly UtcToday { get; }
}
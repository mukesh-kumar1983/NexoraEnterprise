using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Infrastructure.Services;

/// <summary>
/// Default implementation of <see cref="IDateTimeProvider"/>.
/// </summary>
public sealed class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc />
    public DateTime UtcNow => DateTime.UtcNow;

    /// <inheritdoc />
    public DateOnly UtcToday => DateOnly.FromDateTime(DateTime.UtcNow);
}
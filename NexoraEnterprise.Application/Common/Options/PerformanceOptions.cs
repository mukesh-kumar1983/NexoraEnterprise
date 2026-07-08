namespace NexoraEnterprise.Application.Common.Options;

/// <summary>
/// Configuration options for performance monitoring.
/// </summary>
public sealed class PerformanceOptions
{
    /// <summary>
    /// Configuration section name.
    /// </summary>
    public const string SectionName = "Performance";

    /// <summary>
    /// Slow request threshold in milliseconds.
    /// </summary>
    public long SlowRequestThresholdMilliseconds { get; set; } = 500;
}
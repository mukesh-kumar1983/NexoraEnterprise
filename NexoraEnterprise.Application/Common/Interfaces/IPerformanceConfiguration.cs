namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Provides performance monitoring configuration.
/// </summary>
public interface IPerformanceConfiguration
{
    /// <summary>
    /// Gets the slow request threshold in milliseconds.
    /// </summary>
    long SlowRequestThresholdMilliseconds { get; }
}
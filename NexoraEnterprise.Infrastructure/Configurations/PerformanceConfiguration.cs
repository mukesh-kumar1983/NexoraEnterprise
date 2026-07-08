using Microsoft.Extensions.Options;
using NexoraEnterprise.Application.Common.Interfaces;
using NexoraEnterprise.Application.Common.Options;

namespace NexoraEnterprise.Infrastructure.Configuration;

/// <summary>
/// Provides performance configuration from application settings.
/// </summary>
public sealed class PerformanceConfiguration : IPerformanceConfiguration
{
    private readonly PerformanceOptions _options;

    public PerformanceConfiguration(
        IOptions<PerformanceOptions> options)
    {
        _options = options?.Value
            ?? throw new ArgumentNullException(nameof(options));
    }

    /// <inheritdoc />
    public long SlowRequestThresholdMilliseconds =>
        _options.SlowRequestThresholdMilliseconds;
}
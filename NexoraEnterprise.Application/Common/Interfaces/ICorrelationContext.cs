namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Provides access to the current request correlation information.
/// </summary>
public interface ICorrelationContext
{
    /// <summary>
    /// Gets the current correlation identifier.
    /// </summary>
    string CorrelationId { get; }

    /// <summary>
    /// Gets the current distributed trace identifier.
    /// </summary>
    string? TraceId { get; }

    /// <summary>
    /// Gets the current distributed span identifier.
    /// </summary>
    string? SpanId { get; }
}
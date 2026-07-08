using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;
using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Application.Common.Behaviors;

/// <summary>
/// Measures execution time for every MediatR request and logs
/// performance diagnostics for slow requests.
/// </summary>
/// <typeparam name="TRequest">The request type.</typeparam>
/// <typeparam name="TResponse">The response type.</typeparam>
public sealed class PerformanceBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
    private readonly IRequestContext _requestContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IPerformanceConfiguration _configuration;

    public PerformanceBehavior(
        ILogger<PerformanceBehavior<TRequest, TResponse>> logger,
        IRequestContext requestContext,
        IDateTimeProvider dateTimeProvider,
        IPerformanceConfiguration configuration)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _requestContext = requestContext ?? throw new ArgumentNullException(nameof(requestContext));
        _dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var startedAt = Stopwatch.GetTimestamp();

        try
        {
            var response = await next();

            var elapsed = Stopwatch.GetElapsedTime(startedAt);

            LogPerformance(
                LogLevel.Information,
                requestName,
                (long)elapsed.TotalMilliseconds,
                request);

            return response;
        }
        catch (OperationCanceledException)
        {
            var elapsed = Stopwatch.GetElapsedTime(startedAt);

            _logger.LogWarning(
                """
                Request cancelled.

                Request: {Request}
                CorrelationId: {CorrelationId}
                TenantId: {TenantId}
                UserId: {UserId}
                Duration: {Duration} ms
                """,
                requestName,
                _requestContext.CorrelationId,
                _requestContext.TenantId,
                _requestContext.UserId,
                elapsed.TotalMilliseconds);

            throw;
        }
    }

    private void LogPerformance(
        LogLevel defaultLevel,
        string requestName,
        long elapsedMilliseconds,
        object request)
    {
        var level = elapsedMilliseconds >= _configuration.SlowRequestThresholdMilliseconds
            ? LogLevel.Warning
            : defaultLevel;

        _logger.Log(
            level,
            """
            MediatR Request Executed

            Request: {Request}
            Duration: {Duration} ms
            TimestampUtc: {TimestampUtc}

            CorrelationId: {CorrelationId}
            TraceId: {TraceId}
            SpanId: {SpanId}

            TenantId: {TenantId}
            TenantCode: {TenantCode}

            UserId: {UserId}
            UserName: {UserName}

            Payload: {@Payload}
            """,
            requestName,
            elapsedMilliseconds,
            _dateTimeProvider.UtcNow,

            _requestContext.CorrelationId,
            _requestContext.TraceId,
            _requestContext.SpanId,

            _requestContext.TenantId,
            _requestContext.TenantCode,

            _requestContext.UserId,
            _requestContext.UserName,

            request);
    }
}
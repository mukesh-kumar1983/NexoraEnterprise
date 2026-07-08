using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;
using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Application.Common.Behaviors;

/// <summary>
/// Logs every MediatR request before and after execution.
/// </summary>
public sealed class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
    private readonly IRequestContext _requestContext;

    public LoggingBehavior(
        ILogger<LoggingBehavior<TRequest, TResponse>> logger,
        IRequestContext requestContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _requestContext = requestContext ?? throw new ArgumentNullException(nameof(requestContext));
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation(
            """
            ===== MediatR Request Started =====

            Request: {Request}
            CorrelationId: {CorrelationId}
            TenantId: {TenantId}
            TenantCode: {TenantCode}
            UserId: {UserId}
            UserName: {UserName}

            Payload:
            {Payload}
            """,
            requestName,
            _requestContext.CorrelationId,
            _requestContext.TenantId,
            _requestContext.TenantCode,
            _requestContext.UserId,
            _requestContext.UserName,
            JsonSerializer.Serialize(request));

        var response = await next();

        _logger.LogInformation(
            """
            ===== MediatR Request Completed =====

            Request: {Request}

            CorrelationId: {CorrelationId}

            Response:
            {@Response}
            """,
            requestName,
            _requestContext.CorrelationId,
            response);

        return response;
    }
}
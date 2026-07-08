using MediatR;
using Microsoft.Extensions.Logging;
using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Application.Common.Behaviors;

/// <summary>
/// Logs unhandled exceptions occurring during MediatR request processing.
/// The exception is rethrown so it can be handled by the global exception middleware.
/// </summary>
/// <typeparam name="TRequest">Request type.</typeparam>
/// <typeparam name="TResponse">Response type.</typeparam>
public sealed class UnhandledExceptionBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<UnhandledExceptionBehavior<TRequest, TResponse>> _logger;
    private readonly IRequestContext _requestContext;

    public UnhandledExceptionBehavior(
        ILogger<UnhandledExceptionBehavior<TRequest, TResponse>> logger,
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
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                """
                Unhandled exception occurred while processing MediatR request.

                Request: {Request}
                CorrelationId: {CorrelationId}
                TenantId: {TenantId}
                TenantCode: {TenantCode}
                UserId: {UserId}
                UserName: {UserName}

                Payload:
                {@Payload}
                """,
                typeof(TRequest).Name,
                _requestContext.CorrelationId,
                _requestContext.TenantId,
                _requestContext.TenantCode,
                _requestContext.UserId,
                _requestContext.UserName,
                request);

            throw;
        }
    }
}
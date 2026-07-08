using Microsoft.Extensions.Primitives;
using NexoraEnterprise.Application.Common.Constants;

namespace NexoraEnterprise.API.Middlewares;

/// <summary>
/// Middleware responsible for assigning a correlation identifier to every
/// incoming HTTP request.
/// </summary>
public sealed class CorrelationIdMiddleware
{
    /// <summary>
    /// HttpContext.Items key.
    /// </summary>
    public const string CorrelationIdItemName = "CorrelationId";

    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CorrelationIdMiddleware"/> class.
    /// </summary>
    /// <param name="next">Next middleware.</param>
    /// <param name="logger">Logger instance.</param>
    public CorrelationIdMiddleware(
        RequestDelegate next,
        ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Executes the middleware.
    /// </summary>
    /// <param name="context">Current HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        string correlationId;

        if (context.Request.Headers.TryGetValue(
                HeaderNames.CorrelationId,
                out StringValues headerValue)
            && !StringValues.IsNullOrEmpty(headerValue))
        {
            correlationId = headerValue.ToString();
        }
        else
        {
            correlationId = Guid.NewGuid().ToString("N");
        }

        context.Items[CorrelationIdItemName] = correlationId;

        context.Response.OnStarting(() =>
        {
            context.Response.Headers[HeaderNames.CorrelationId] = correlationId;
            return Task.CompletedTask;
        });

        using (_logger.BeginScope(new Dictionary<string, object>
        {
            ["CorrelationId"] = correlationId
        }))
        {
            await _next(context);
        }
    }

    /// <summary>
    /// Gets the current request correlation identifier.
    /// </summary>
    /// <param name="context">HTTP context.</param>
    /// <returns>Correlation identifier if available.</returns>
    public static string? GetCorrelationId(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.Items.TryGetValue(
            CorrelationIdItemName,
            out var value)
            ? value?.ToString()
            : null;
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using NexoraEnterprise.API.Constants;

namespace NexoraEnterprise.API.Middlewares;

/// <summary>
/// Logs every HTTP request and response with execution time and
/// diagnostic information.
/// </summary>
public sealed class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestLoggingMiddleware"/> class.
    /// </summary>
    public RequestLoggingMiddleware(
        RequestDelegate next,
        ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Executes the middleware.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var stopwatch = Stopwatch.StartNew();

        var request = context.Request;

        var correlationId =
            CorrelationIdMiddleware.GetCorrelationId(context)
            ?? context.TraceIdentifier;

        var method = request.Method;

        var url = request.GetDisplayUrl();

        var remoteIp =
            context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

        var userAgent = request.Headers.UserAgent.ToString();

        var requestSize = request.ContentLength ?? 0;

        var user =
            context.User.Identity?.IsAuthenticated == true
                ? context.User.Identity.Name
                : "Anonymous";

        try
        {
            await _next(context);

            stopwatch.Stop();

            var responseSize = context.Response.ContentLength ?? 0;

            _logger.LogInformation(
                """
                HTTP Request completed.
                CorrelationId: {CorrelationId}
                User: {User}
                Method: {Method}
                Url: {Url}
                StatusCode: {StatusCode}
                Duration: {ElapsedMilliseconds} ms
                ClientIP: {ClientIp}
                RequestSize: {RequestSize}
                ResponseSize: {ResponseSize}
                UserAgent: {UserAgent}
                """,
                correlationId,
                user,
                method,
                url,
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds,
                remoteIp,
                requestSize,
                responseSize,
                userAgent);
        }
        catch
        {
            stopwatch.Stop();

            _logger.LogError(
                """
                HTTP Request failed.
                CorrelationId: {CorrelationId}
                User: {User}
                Method: {Method}
                Url: {Url}
                Duration: {ElapsedMilliseconds} ms
                ClientIP: {ClientIp}
                UserAgent: {UserAgent}
                """,
                correlationId,
                user,
                method,
                url,
                stopwatch.ElapsedMilliseconds,
                remoteIp,
                userAgent);

            throw;
        }
    }
}
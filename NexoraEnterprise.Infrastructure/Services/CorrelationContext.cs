using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using NexoraEnterprise.Application.Common.Constants;
using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Infrastructure.Services;

/// <summary>
/// Provides correlation and distributed tracing information
/// for the current request.
/// </summary>
public sealed class CorrelationContext : ICorrelationContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CorrelationContext(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor
            ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public string CorrelationId
    {
        get
        {
            var context = _httpContextAccessor.HttpContext;

            if (context is null)
            {
                return Guid.NewGuid().ToString("N");
            }

            if (context.Request.Headers.TryGetValue(
                    HeaderNames.CorrelationId,
                    out var values))
            {
                var correlationId = values.ToString();

                if (!string.IsNullOrWhiteSpace(correlationId))
                {
                    return correlationId;
                }
            }

            return context.TraceIdentifier;
        }
    }

    public string? TraceId =>
        Activity.Current?.TraceId.ToString();

    public string? SpanId =>
        Activity.Current?.SpanId.ToString();
}
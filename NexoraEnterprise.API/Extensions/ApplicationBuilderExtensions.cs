using Microsoft.AspNetCore.Builder;
using NexoraEnterprise.API.Middlewares;

namespace NexoraEnterprise.API.Extensions;

/// <summary>
/// Extension methods for configuring the application's HTTP request pipeline.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Registers the Correlation Id middleware.
    /// This should be the first custom middleware executed.
    /// </summary>
    /// <param name="app">Application builder.</param>
    /// <returns>The application builder.</returns>
    public static IApplicationBuilder UseCorrelationId(
        this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return app.UseMiddleware<CorrelationIdMiddleware>();
    }

    /// <summary>
    /// Registers the request logging middleware.
    /// </summary>
    /// <param name="app">Application builder.</param>
    /// <returns>The application builder.</returns>
    public static IApplicationBuilder UseRequestLogging(
        this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return app.UseMiddleware<RequestLoggingMiddleware>();
    }

    /// <summary>
    /// Registers the global exception handling middleware.
    /// </summary>
    /// <param name="app">Application builder.</param>
    /// <returns>The application builder.</returns>
    public static IApplicationBuilder UseGlobalExceptionHandler(
        this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}
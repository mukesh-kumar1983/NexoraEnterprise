using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NexoraEnterprise.Application.Common.Exceptions;
using NexoraEnterprise.Domain.Exceptions;
using AppValidationException = NexoraEnterprise.Application.Common.Exceptions.ValidationException;

namespace NexoraEnterprise.API.Middlewares;

/// <summary>
/// Global exception handling middleware that converts unhandled exceptions
/// into RFC 7807 Problem Details responses.
/// </summary>
public sealed class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptionMiddleware"/> class.
    /// </summary>
    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _environment = environment ?? throw new ArgumentNullException(nameof(environment));
    }

    /// <summary>
    /// Executes the middleware.
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        _logger.LogError(
            exception,
            "Unhandled exception while processing {Method} {Path}. TraceId: {TraceId}",
            context.Request.Method,
            context.Request.Path,
            context.TraceIdentifier);

        var (statusCode, title) = GetExceptionDetails(exception);

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";

        var problem = CreateProblemDetails(
            context,
            exception,
            statusCode,
            title);

        await context.Response.WriteAsJsonAsync(problem);
    }

    private ProblemDetails CreateProblemDetails(
        HttpContext context,
        Exception exception,
        int statusCode,
        string title)
    {
        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Instance = context.Request.Path,
            Type = $"https://httpstatuses.com/{statusCode}"
        };

        problem.Extensions["traceId"] = context.TraceIdentifier;
        problem.Extensions["timestamp"] = DateTimeOffset.UtcNow;

        if (_environment.IsDevelopment())
        {
            problem.Detail = exception.Message;
            problem.Extensions["exception"] = exception.GetType().Name;
            problem.Extensions["stackTrace"] = exception.StackTrace;
        }

        if (exception is
            AppValidationException
            validationException)
        {
            problem.Extensions["errors"] = validationException.Errors;
        }

        if (exception is FluentValidation.ValidationException fluentValidationException)
        {
            problem.Extensions["errors"] =
                fluentValidationException.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray());
        }

        return problem;
    }

    private static (int StatusCode, string Title) GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            NexoraEnterprise.Application.Common.Exceptions.ValidationException =>
                (StatusCodes.Status400BadRequest, "Validation Failed"),

            FluentValidation.ValidationException =>
                (StatusCodes.Status400BadRequest, "Validation Failed"),

            NotFoundException =>
                (StatusCodes.Status404NotFound, "Resource Not Found"),

            ConflictException =>
                (StatusCodes.Status409Conflict, "Conflict"),

            UnauthorizedException =>
                (StatusCodes.Status401Unauthorized, "Unauthorized"),

            ForbiddenException =>
                (StatusCodes.Status403Forbidden, "Forbidden"),

            DomainException =>
                (StatusCodes.Status400BadRequest, "Business Rule Violation"),

            _ =>
                (StatusCodes.Status500InternalServerError, "Internal Server Error")
        };
    }
}
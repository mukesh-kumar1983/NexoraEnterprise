using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NexoraEnterprise.Application.Behaviors;
using NexoraEnterprise.Application.Common.Behaviors;


namespace NexoraEnterprise.Application;

/// <summary>
/// Registers Application layer services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers all Application services.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Register all FluentValidation validators
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), 
            typeof(ValidationBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), 
            typeof(LoggingBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), 
            typeof(PerformanceBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), 
            typeof(TransactionBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), 
            typeof(UnhandledExceptionBehavior<,>));

        return services;
    }
}
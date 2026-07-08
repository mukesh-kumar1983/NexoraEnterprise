using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexoraEnterprise.Application.Abstractions.Persistence;
using NexoraEnterprise.Application.Common.Interfaces;
using NexoraEnterprise.Application.Common.Options;
using NexoraEnterprise.Infrastructure.Configuration;
using NexoraEnterprise.Infrastructure.Persistence;
using NexoraEnterprise.Infrastructure.Persistence.Repositories;
using NexoraEnterprise.Infrastructure.Services;

namespace NexoraEnterprise.Infrastructure;

/// <summary>
/// Registers Infrastructure services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers Infrastructure dependencies.
    /// </summary>
    /// <param name="services">
    /// The service collection.
    /// </param>
    /// <param name="configuration">
    /// Application configuration.
    /// </param>
    /// <returns>
    /// The updated service collection.
    /// </returns>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddHttpContextAccessor();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ITenantRepository, TenantRepository>();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddScoped<ICurrentTenantService, CurrentTenantService>();

        services.AddScoped<ICorrelationContext, CorrelationContext>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IRequestContext, RequestContext>();

        services.Configure<PerformanceOptions>(
        configuration.GetSection(PerformanceOptions.SectionName));

        services.AddSingleton<IPerformanceConfiguration, PerformanceConfiguration>();

        //services.AddScoped<IUnitOfWork>(sp =>
        //sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
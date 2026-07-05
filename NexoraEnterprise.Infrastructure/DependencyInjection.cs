using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NexoraEnterprise.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register Infrastructure services here

        return services;
    }
}
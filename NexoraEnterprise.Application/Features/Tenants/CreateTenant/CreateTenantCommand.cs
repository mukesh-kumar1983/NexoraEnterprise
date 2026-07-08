using NexoraEnterprise.Application.Abstractions.CQRS;

namespace NexoraEnterprise.Application.Features.Tenants.Commands.Create;

/// <summary>
/// Command used to register a new tenant.
/// </summary>
public sealed record CreateTenantCommand(
    string Code,
    string Name)
    : ICommand<CreateTenantResponse>;
using NexoraEnterprise.Application.Abstractions.CQRS;
using NexoraEnterprise.Application.Abstractions.Persistence;
using NexoraEnterprise.Application.Common.Interfaces;
using NexoraEnterprise.Application.Common.Results;
using NexoraEnterprise.Application.Features.Tenants.Commands.Create;
using NexoraEnterprise.Domain.Entities.Tenants;

namespace NexoraEnterprise.Application.Features.Tenants.CreateTenant;

/// <summary>
/// Handles the creation of a new tenant.
/// </summary>
public sealed class CreateTenantCommandHandler
    : ICommandHandler<CreateTenantCommand, CreateTenantResponse>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTenantCommandHandler"/> class.
    /// </summary>
    /// <param name="tenantRepository">
    /// Repository used to manage tenant aggregates.
    /// </param>
    /// <param name="unitOfWork">
    /// Coordinates persistence across repositories.
    /// </param>
    public CreateTenantCommandHandler(
        ITenantRepository tenantRepository,
        IUnitOfWork unitOfWork)
    {
        _tenantRepository = tenantRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<Result<CreateTenantResponse>> Handle(
        CreateTenantCommand command,
        CancellationToken cancellationToken = default)
    {
        var exists = await _tenantRepository.ExistsByCodeAsync(
            command.Code,
            cancellationToken);

        if (exists)
        {
            return Result.Failure<CreateTenantResponse>(
                Error.Conflict(
                    "Tenant.CodeAlreadyExists",
                    $"A tenant with code '{command.Code}' already exists."));
        }

        Tenant tenant = Tenant.Create(
            command.Code,
            command.Name);

        await _tenantRepository.AddAsync(
            tenant,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result.Success(
            new CreateTenantResponse
            {
                Id = tenant.Id,
                Code = tenant.Code,
                Name = tenant.Name,
                Status = tenant.Status
            });
    }
}
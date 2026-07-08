using FluentValidation;
using NexoraEnterprise.Application.Common.Constants;

namespace NexoraEnterprise.Application.Features.Tenants.Commands.Create;

/// <summary>
/// Validates the CreateTenantCommand.
/// </summary>
public sealed class CreateTenantCommandValidator
    : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Tenant code is required.")
            .MinimumLength(TenantConstants.CodeMinLength)
            .MaximumLength(TenantConstants.CodeMaxLength);

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Tenant name is required.")
            .MinimumLength(TenantConstants.NameMinLength)
            .MaximumLength(TenantConstants.NameMaxLength);
    }
}
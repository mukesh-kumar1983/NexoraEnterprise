using NexoraEnterprise.Domain.Enums;

namespace NexoraEnterprise.Domain.Rules.Tenants;

/// <summary>
/// Business rule that prevents an inactive tenant from being activated again.
///
/// An inactive tenant is considered permanently closed.
/// If the business ever requires reactivation, it should be implemented
/// as a dedicated business process rather than simply changing the status.
/// </summary>
public sealed class TenantCannotBeActivatedWhenInactiveRule : BusinessRule
{
    private readonly TenantStatus _currentStatus;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantCannotBeActivatedWhenInactiveRule"/> class.
    /// </summary>
    /// <param name="currentStatus">Current tenant status.</param>
    public TenantCannotBeActivatedWhenInactiveRule(TenantStatus currentStatus)
    {
        _currentStatus = currentStatus;
    }

    /// <inheritdoc />
    public override bool IsBroken()
    {
        return _currentStatus == TenantStatus.Inactive;
    }

    /// <inheritdoc />
    public override string Message
    {
        get => "An inactive tenant cannot be activated.";
    }

    /// <inheritdoc />
    public override string ErrorCode
    {
        get => "TENANT_CANNOT_BE_ACTIVATED";
    }
}
namespace NexoraEnterprise.Domain.Enums;

/// <summary>
/// Represents the lifecycle status of a tenant.
///
/// A tenant progresses through these states during its lifetime.
/// Business operations may be restricted depending on the current status.
/// </summary>
public enum TenantStatus
{
    /// <summary>
    /// The tenant has been registered but is not yet active.
    /// </summary>
    Pending = 0,

    /// <summary>
    /// The tenant is active and can access all enabled modules.
    /// </summary>
    Active = 1,

    /// <summary>
    /// The tenant has been temporarily suspended.
    /// Users belonging to the tenant cannot access the system.
    /// </summary>
    Suspended = 2,

    /// <summary>
    /// The tenant has been permanently deactivated.
    /// This is a terminal state and cannot be activated again.
    /// </summary>
    Inactive = 3
}
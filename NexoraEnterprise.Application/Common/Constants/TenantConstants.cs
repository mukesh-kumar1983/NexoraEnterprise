namespace NexoraEnterprise.Application.Common.Constants;

/// <summary>
/// Defines business constants for the Tenant aggregate.
///
/// These values are shared across:
/// - FluentValidation
/// - EF Core configuration
/// - API validation
/// - UI validation
///
/// Keeping them in one place prevents magic numbers
/// from being duplicated throughout the solution.
/// </summary>
public static class TenantConstants
{
    /// <summary>
    /// Minimum tenant code length.
    /// </summary>
    public const int CodeMinLength = 2;

    /// <summary>
    /// Maximum tenant code length.
    /// </summary>
    public const int CodeMaxLength = 20;

    /// <summary>
    /// Minimum tenant name length.
    /// </summary>
    public const int NameMinLength = 2;

    /// <summary>
    /// Maximum tenant name length.
    /// </summary>
    public const int NameMaxLength = 200;
}
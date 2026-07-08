namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Provides information about the currently authenticated user.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the unique identifier of the current user.
    /// Returns <c>null</c> when the request is anonymous.
    /// </summary>
    Guid? UserId { get; }

    /// <summary>
    /// Gets the current user's username.
    /// </summary>
    string? UserName { get; }

    /// <summary>
    /// Gets the current user's email address.
    /// </summary>
    string? Email { get; }

    /// <summary>
    /// Gets whether the current request is authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Determines whether the current user belongs to the specified role.
    /// </summary>
    /// <param name="role">Role name.</param>
    /// <returns><c>true</c> if the user belongs to the role; otherwise <c>false</c>.</returns>
    bool IsInRole(string role);

    /// <summary>
    /// Returns all claims associated with the current user.
    /// </summary>
    IReadOnlyCollection<KeyValuePair<string, string>> Claims { get; }
}
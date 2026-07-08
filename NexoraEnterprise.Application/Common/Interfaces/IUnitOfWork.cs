namespace NexoraEnterprise.Application.Common.Interfaces;

/// <summary>
/// Represents a unit of work.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Persists all pending changes.
    /// </summary>
    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
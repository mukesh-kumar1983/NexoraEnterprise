using NexoraEnterprise.Application.Common.Results;

namespace NexoraEnterprise.Application.Abstractions.CQRS;

/// <summary>
/// Represents a handler for a query.
/// </summary>
/// <typeparam name="TQuery">
/// The query type.
/// </typeparam>
/// <typeparam name="TResponse">
/// The response type.
/// </typeparam>
public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IApplicationQuery<TResponse>
{
    /// <summary>
    /// Handles the specified query.
    /// </summary>
    /// <param name="query">
    /// The query.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// A <see cref="Result{TValue}"/> containing the requested data.
    /// </returns>
    Task<Result<TResponse>> Handle(
        TQuery query,
        CancellationToken cancellationToken = default);
}
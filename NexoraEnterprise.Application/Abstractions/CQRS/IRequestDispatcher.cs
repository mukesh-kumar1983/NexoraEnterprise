using NexoraEnterprise.Application.Common.Results;

namespace NexoraEnterprise.Application.Abstractions.CQRS;

/// <summary>
/// Dispatches application requests to their corresponding handlers.
///
/// This abstraction hides the underlying messaging library
/// (currently MediatR) from the Application layer.
///
/// The Application layer depends only on this contract and
/// remains completely unaware of the underlying dispatcher.
/// </summary>
public interface IRequestDispatcher
{
    /// <summary>
    /// Sends a command that does not return data.
    /// </summary>
    /// <param name="request">
    /// The application request to execute.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> describing whether the operation
    /// completed successfully.
    /// </returns>
    Task<Result> SendAsync(
        IApplicationRequest request,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a request that returns data.
    /// </summary>
    /// <typeparam name="TResponse">
    /// The response type.
    /// </typeparam>
    /// <param name="request">
    /// The request to execute.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// A <see cref="Result{TResponse}"/> containing the requested
    /// response or one or more errors.
    /// </returns>
    Task<Result<TResponse>> SendAsync<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default);
}
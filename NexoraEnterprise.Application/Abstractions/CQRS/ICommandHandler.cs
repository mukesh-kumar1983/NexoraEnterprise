using NexoraEnterprise.Application.Common.Results;

namespace NexoraEnterprise.Application.Abstractions.CQRS;

/// <summary>
/// Represents a handler for a command that does not return data.
/// </summary>
/// <typeparam name="TCommand">
/// The command type.
/// </typeparam>
public interface ICommandHandler<in TCommand>
    where TCommand : IApplicationCommand
{
    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">
    /// The command to handle.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// A <see cref="Result"/> indicating the outcome of the operation.
    /// </returns>
    Task<Result> Handle(
        TCommand command,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a handler for a command that returns data.
/// </summary>
/// <typeparam name="TCommand">
/// The command type.
/// </typeparam>
/// <typeparam name="TResponse">
/// The response type.
/// </typeparam>
public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">
    /// The command to handle.
    /// </param>
    /// <param name="cancellationToken">
    /// The cancellation token.
    /// </param>
    /// <returns>
    /// A <see cref="Result{TValue}"/> containing the operation result.
    /// </returns>
    Task<Result<TResponse>> Handle(
        TCommand command,
        CancellationToken cancellationToken = default);
}
namespace NexoraEnterprise.Application.Abstractions.CQRS;

/// <summary>
/// Represents a command that does not return data.
/// </summary>
public interface IApplicationCommand : IApplicationRequest
{
}

/// <summary>
/// Represents a command that returns data.
/// </summary>
/// <typeparam name="TResponse">
/// The response type.
/// </typeparam>
public interface ICommand<TResponse> : IRequest<TResponse>
{
}
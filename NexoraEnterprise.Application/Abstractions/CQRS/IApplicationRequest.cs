namespace NexoraEnterprise.Application.Abstractions.CQRS;

/// <summary>
/// Represents a request within the CQRS pipeline.
/// </summary>
public interface IApplicationRequest
{
}

/// <summary>
/// Represents a request that returns a response.
/// </summary>
/// <typeparam name="TResponse">
/// The response type.
/// </typeparam>
public interface IRequest<out TResponse> : IApplicationRequest
{
}
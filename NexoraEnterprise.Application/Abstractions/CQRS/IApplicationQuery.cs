namespace NexoraEnterprise.Application.Abstractions.CQRS;

/// <summary>
/// Represents a query that returns data.
/// </summary>
/// <typeparam name="TResponse">
/// The response type.
/// </typeparam>
public interface IApplicationQuery<TResponse> : IRequest<TResponse>
{
}
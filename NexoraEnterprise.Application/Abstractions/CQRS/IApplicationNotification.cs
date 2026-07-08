namespace NexoraEnterprise.Application.Abstractions.CQRS;

/// <summary>
/// Represents a notification/event that can be published
/// within the application.
///
/// Notifications are intended for in-process messaging.
/// Domain Events will implement this contract through
/// the infrastructure adapter when required.
/// </summary>
public interface IApplicationNotification
{
}
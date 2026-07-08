using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Infrastructure.Services;

/// <summary>
/// Default implementation of <see cref="IRequestContext"/>.
/// </summary>
public sealed class RequestContext : IRequestContext
{
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentTenantService _currentTenant;
    private readonly ICorrelationContext _correlationContext;

    public RequestContext(
        ICurrentUserService currentUser,
        ICurrentTenantService currentTenant,
        ICorrelationContext correlationContext)
    {
        _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        _currentTenant = currentTenant ?? throw new ArgumentNullException(nameof(currentTenant));
        _correlationContext = correlationContext ?? throw new ArgumentNullException(nameof(correlationContext));
    }

    public string CorrelationId => _correlationContext.CorrelationId;

    public string? TraceId => _correlationContext.TraceId;

    public string? SpanId => _correlationContext.SpanId;

    public Guid? UserId => _currentUser.UserId;

    public string? UserName => _currentUser.UserName;

    public string? Email => _currentUser.Email;

    public bool IsAuthenticated => _currentUser.IsAuthenticated;

    public Guid? TenantId => _currentTenant.TenantId;

    public string? TenantCode => _currentTenant.TenantCode;

    public string? TenantName => _currentTenant.TenantName;
}
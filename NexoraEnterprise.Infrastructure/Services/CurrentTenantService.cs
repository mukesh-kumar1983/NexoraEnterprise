using Microsoft.AspNetCore.Http;
using NexoraEnterprise.Application.Common.Interfaces;

namespace NexoraEnterprise.Infrastructure.Services;

/// <summary>
/// Provides access to the current tenant resolved by the request pipeline.
/// </summary>
public sealed class CurrentTenantService : ICurrentTenantService
{
    private const string TenantIdKey = "TenantId";
    private const string TenantCodeKey = "TenantCode";
    private const string TenantNameKey = "TenantName";

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentTenantService(
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor
            ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    private HttpContext? HttpContext => _httpContextAccessor.HttpContext;

    /// <inheritdoc />
    public Guid? TenantId
    {
        get
        {
            var value = HttpContext?.Items[TenantIdKey]?.ToString();

            return Guid.TryParse(value, out var id)
                ? id
                : null;
        }
    }

    /// <inheritdoc />
    public string? TenantCode =>
        HttpContext?.Items[TenantCodeKey]?.ToString();

    /// <inheritdoc />
    public string? TenantName =>
        HttpContext?.Items[TenantNameKey]?.ToString();

    /// <inheritdoc />
    public bool HasTenant => TenantId.HasValue;
}
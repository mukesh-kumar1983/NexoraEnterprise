using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoraEnterprise.Domain.Constants;
using NexoraEnterprise.Domain.Entities.Tenants;

namespace NexoraEnterprise.Infrastructure.Persistence.Configurations;

/// <summary>
/// Configures the Tenant aggregate.
/// </summary>
public sealed class TenantConfiguration
    : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(TenantConstants.CodeMaxLength)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(TenantConstants.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.RegisteredOn)
            .IsRequired();

        builder.Property(x => x.CreatedOn)
            .IsRequired();

        builder.Property(x => x.CreatedBy);

        builder.Property(x => x.ModifiedOn);

        builder.Property(x => x.ModifiedBy);

        builder.Property(x => x.DeletedOn);

        builder.Property(x => x.DeletedBy);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}
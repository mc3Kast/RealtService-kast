using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;
public class ResidentialLeasingConfiguration : IEntityTypeConfiguration<ResidentialLeasing>
{
    public void Configure(EntityTypeBuilder<ResidentialLeasing> builder)
    {
        builder.HasBaseType<ResidentialTerm>();

        builder.HasMany<ResidentialLeasingRequirement>(leasing => leasing.Requirements)
            .WithMany(requirement => requirement.Leasings);

        builder.Property<decimal?>(nameof(ResidentialLeasing.PricePerDay))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property<decimal?>(nameof(ResidentialLeasing.PricePerMonth))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property<decimal?>(nameof(ResidentialLeasing.PricePerYear))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);
    }
}

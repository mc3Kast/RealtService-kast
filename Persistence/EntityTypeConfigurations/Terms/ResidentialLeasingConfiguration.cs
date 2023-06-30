using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;
public class ResidentialLeasingConfiguration : IEntityTypeConfiguration<ResidentialLeasing>
{
    public void Configure(EntityTypeBuilder<ResidentialLeasing> builder)
    {
        builder.HasBaseType<ResidentialTerm>();

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

        builder.Property<bool>(nameof(ResidentialLeasing.AllowedGirls))
            .HasColumnName("AllowedGirls")
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

        builder.Property<bool>(nameof(ResidentialLeasing.AllowedBoys))
            .HasColumnName("AllowedBoys")
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

        builder.Property<bool>(nameof(ResidentialLeasing.AllowedPets))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

        builder.Property<bool>(nameof(ResidentialLeasing.AllowedAlcohol))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

        builder.ToTable(builder => builder.HasCheckConstraint("CK_At_Least_One_Allowed", "[AllowedGirls] <> 0 AND [AllowedBoys] <> 0"));
    }
}

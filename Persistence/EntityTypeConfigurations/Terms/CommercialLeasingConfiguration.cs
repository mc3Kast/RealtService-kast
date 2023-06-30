using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class CommercialLeasingConfiguration : IEntityTypeConfiguration<CommercialLeasing>
{
    public void Configure(EntityTypeBuilder<CommercialLeasing> builder)
    {
        builder.HasBaseType<CommercialTerm>();

        builder.Property<decimal?>(nameof(CommercialLeasing.PricePerMonth))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property<decimal?>(nameof(CommercialLeasing.PricePerMonth))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property<bool>(nameof(CommercialLeasing.AllowedManufacturing))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

        builder.Property<bool>(nameof(CommercialLeasing.AllowedScheduling))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();

    }
}

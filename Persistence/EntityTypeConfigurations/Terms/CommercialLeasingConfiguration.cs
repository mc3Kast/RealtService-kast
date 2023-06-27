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

        builder.HasMany<CommercialLeasingRequirement>(leasing => leasing.Requirements)
            .WithMany(requirement => requirement.Leasings);

        builder.Property<decimal?>(nameof(CommercialLeasing.PricePerMonth))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Property<decimal?>(nameof(CommercialLeasing.PricePerMonth))
            .HasColumnType("money")
            .HasDefaultValue(null)
            .IsRequired(false);

        builder.Navigation(leasing => leasing.Requirements).AutoInclude();
    }
}

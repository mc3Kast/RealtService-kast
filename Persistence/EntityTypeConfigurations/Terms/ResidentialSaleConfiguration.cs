using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class ResidentialSaleConfiguration : IEntityTypeConfiguration<ResidentialSale>
{
    public void Configure(EntityTypeBuilder<ResidentialSale> builder)
    {
        builder.HasBaseType<ResidentialTerm>();

        builder.Property<decimal>(nameof(ResidentialSale.Price))
            .HasColumnType("money")
            .IsRequired();
    }
}

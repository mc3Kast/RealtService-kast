using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.HasBaseType<CommercialEstate>();

        builder.Property<float>(nameof(Warehouse.CeilingHeight))
            .IsRequired();

        builder.Property<bool>(nameof(Warehouse.HasClimateControl))
            .HasColumnType("tinyint")
            .HasConversion<int>()
            .IsRequired();
    }
}

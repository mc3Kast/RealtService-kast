using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

internal class FlatConfiguration : IEntityTypeConfiguration<Flat>
{
    public void Configure(EntityTypeBuilder<Flat> builder)
    {
        builder.HasBaseType<ResidentialEstate>();

        builder.Property<int>(nameof(Flat.StoreyNumber))
            .IsRequired();

        builder.Property<int>(nameof(Flat.RoomNumber))
            .IsRequired();

        builder.Property<int>(nameof(Flat.WCNumber))
            .IsRequired();
    }
}

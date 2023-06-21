using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class RoomsConfiguration : IEntityTypeConfiguration<Rooms>
{
    public void Configure(EntityTypeBuilder<Rooms> builder)
    {
        builder.HasBaseType<ResidentialEstate>();

        builder.Property<int>(nameof(Rooms.StoreyNumber))
            .IsRequired();

        builder.Property<int>(nameof(Rooms.RoomNumber))
            .IsRequired();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class AgencyConfiguration : IEntityTypeConfiguration<Agency>
{
    public void Configure(EntityTypeBuilder<Agency> builder)
    {
        builder.HasBaseType<User>();

        builder.Property(agency => agency.AgencyUniqueNumber)
            .IsRequired(false);
    }
}

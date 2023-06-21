using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Estates;

public class ResidentialEstateConfiguration : IEntityTypeConfiguration<ResidentialEstate>
{
    public void Configure(EntityTypeBuilder<ResidentialEstate> builder)
    {
        builder.HasBaseType<Estate>();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class CommercialLeasingRequirementConfiguration : IEntityTypeConfiguration<CommercialLeasingRequirement>
{
    public void Configure(EntityTypeBuilder<CommercialLeasingRequirement> builder)
    {
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.Id).IsUnique();

        builder.Property<int>(nameof(CommercialLeasingRequirement.Id))
           .IsRequired()
           .ValueGeneratedOnAdd()
           .HasColumnType("tinyint")
           .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<string>(nameof(CommercialLeasingRequirement.Name))
           .IsRequired()
           .HasMaxLength(255);
    }
}

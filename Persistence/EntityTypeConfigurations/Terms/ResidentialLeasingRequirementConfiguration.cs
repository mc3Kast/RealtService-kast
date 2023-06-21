using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Terms;

public class ResidentialLeasingRequirementConfiguration : IEntityTypeConfiguration<ResidentialLeasingRequirement>
{
    public void Configure(EntityTypeBuilder<ResidentialLeasingRequirement> builder)
    {
        builder.HasKey(leasing => leasing.Id);
        builder.HasIndex(leasing => leasing.Id).IsUnique();

        builder.Property<int>(nameof(ResidentialLeasingRequirement.Id))
           .IsRequired()
           .ValueGeneratedOnAdd()
           .HasColumnType("tinyint")
           .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<string>(nameof(ResidentialLeasingRequirement.Name))
           .IsRequired()
           .HasMaxLength(255);
    }
}

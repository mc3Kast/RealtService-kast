using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasKey(roleClaim => roleClaim.Id);

        builder.Property(roleClaim => roleClaim.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.ToTable("RoleClaims");

        //Relations defined in UserRoleConfiguration
    }
}

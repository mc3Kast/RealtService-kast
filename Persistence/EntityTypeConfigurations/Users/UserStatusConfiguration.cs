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

public class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
{
    public void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        builder.HasKey(status => status.Id);

        builder.Property(status => status.Id)
              .ValueGeneratedOnAdd()
              .HasColumnType("int")
              .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property(status => status.Name)
            .HasMaxLength(256)
            .IsRequired();
    }
}

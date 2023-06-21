using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property<int>(nameof(UserRole.Id))
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnType("tinyint")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<string>(nameof(UserRole.Name))
            .IsRequired()
            .HasMaxLength(255);

        builder.HasData(new UserRole[]
        {
            new UserRole() { Id = 1, Name = "User" },
            new UserRole() { Id = 2, Name = "Admin" }
        });

    }
}

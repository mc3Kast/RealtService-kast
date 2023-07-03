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

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(role => role.Id);

        builder.Property(role => role.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.HasIndex(role => role.NormalizedName)
            .HasDatabaseName("RoleNameIndex")
            .IsUnique();

        builder.ToTable("Roles");

        builder.Property(role => role.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.Property(role => role.Name)
            .HasMaxLength(256);

        builder.Property(role => role.NormalizedName)
            .HasMaxLength(256);

        builder.HasMany(role => role.UserBelongsToRoles)
            .WithOne(userBelongsToRole => userBelongsToRole.Role)
            .HasForeignKey(userBelongsToRole => userBelongsToRole.RoleId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasMany(role => role.Claims)
            .WithOne(roleClaim => roleClaim.Role)
            .HasForeignKey(roleClaim => roleClaim.RoleId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.Navigation(role => role.Claims).AutoInclude();
        builder.Navigation(role => role.UserBelongsToRoles).AutoInclude();
    }
}

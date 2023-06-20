using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Users.Misc;

internal class UserStatusConfiguration : IEntityTypeConfiguration<UserStatus>
{
    public void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property<int>(nameof(UserStatus.Id))
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnType("tinyint")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<string>(nameof(UserStatus.Name))
            .IsRequired()
            .HasMaxLength(255);

        builder.HasData(new UserStatus[]
        {
            new UserStatus() { Id = 1, Name = "Online" },
            new UserStatus() { Id = 2, Name = "Offline" }
        });
    }
}

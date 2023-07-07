using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Users;

namespace RealtService.Persistence.EntityTypeConfigurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
              .ValueGeneratedOnAdd()
              .HasColumnType("int")
              .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.UseTphMappingStrategy();

        builder.HasIndex(user => user.NormalizedUserName)
            .HasDatabaseName("UserNameIndex")
            .IsUnique();

        builder.HasIndex(user => user.NormalizedEmail)
            .HasDatabaseName("EmailIndex")
            .IsUnique();

        builder.ToTable("Users");

        builder.Property(user => user.ConcurrencyStamp)
            .IsConcurrencyToken();

        builder.Property(user => user.UserName)
            .HasMaxLength(256);

        builder.Property(user => user.NormalizedUserName)
            .HasMaxLength(256);

        builder.Property(user => user.Email)
            .HasMaxLength(256);

        builder.Property(user => user.NormalizedEmail)
            .HasMaxLength(256);

        builder.HasMany(user => user.Claims)
            .WithOne(userClaim => userClaim.User)
            .HasForeignKey(claim => claim.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(user => user.Logins)
            .WithOne(login => login.User)
            .HasForeignKey(login => login.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(user => user.Tokens)
            .WithOne(token => token.User)
            .HasForeignKey(token => token.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(user => user.BelongsToRoles)
            .WithOne(ubtroles => ubtroles.User)
            .HasForeignKey(ubtroles => ubtroles.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(user => user.Contacts)
            .WithOne(contact => contact.User)
            .HasForeignKey(contact => contact.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(user => user.Offers)
            .WithOne(offer => offer.User)
            .HasForeignKey(offer => offer.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Navigation(user => user.Logins).AutoInclude();
        builder.Navigation(user => user.Tokens).AutoInclude();
        builder.Navigation(user => user.Claims).AutoInclude();
        builder.Navigation(user => user.Contacts).AutoInclude();
        builder.Navigation(user => user.BelongsToRoles).AutoInclude();
    }
}

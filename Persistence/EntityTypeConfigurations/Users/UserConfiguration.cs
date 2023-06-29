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

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.Id).IsUnique();

        builder.UseTphMappingStrategy();

        builder.HasMany(user => user.Roles)
               .WithMany(role => role.Users);

        builder.HasOne(user => user.Status)
               .WithMany()
               .HasForeignKey("StatusId")
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

        builder.HasMany(user => user.Contacts)
               .WithOne(contact => contact.User)
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
        
        builder.HasMany<Offer>(user => user.Offers)
               .WithOne(offer => offer.User)
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired(false);

        builder.Property<int>(nameof(User.Id))
               .IsRequired()
               .ValueGeneratedOnAdd()
               .HasColumnType("int")
               .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<string>(nameof(User.Email))
               .IsRequired()
               .HasMaxLength(255);

        builder.Property<string>(nameof(User.HashPassword))
               .IsRequired()
               .HasMaxLength(255);

        builder.Property<string>(nameof(UserContact.Name))
               .IsRequired()
               .HasMaxLength(255);

        builder.Property<DateTime>(nameof(User.RegistrationDate))
               .IsRequired();

        builder.Navigation(user => user.Offers).AutoInclude();
        //builder.Navigation(user => user.Status).AutoInclude();
        //builder.Navigation(user => user.Roles).AutoInclude();
    }
}

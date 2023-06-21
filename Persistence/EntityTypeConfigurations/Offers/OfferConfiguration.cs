using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Offers;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(offer => offer.Id);
        builder.HasIndex(offer => offer.Id).IsUnique();

        builder.UseTpcMappingStrategy();

        builder.HasOne<User>(offer => offer.User)
            .WithMany(user => user.Offers)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.Property<int>(nameof(Offer.Id))
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnType("int")
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

        builder.Property<DateTime>(nameof(Offer.PublicationDate))
            .IsRequired();

        builder.Property<string?>(nameof(Offer.Description))
            .IsRequired(false);
    }
}

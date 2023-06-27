using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Offers;

public class CommercialOfferConfiguration : IEntityTypeConfiguration<CommercialOffer>
{
    public void Configure(EntityTypeBuilder<CommercialOffer> builder)
    {
        builder.HasBaseType<Offer>();

        builder.HasOne<CommercialEstate>(offer => offer.Estate)
            .WithOne(estate => estate.Offer)
            .HasForeignKey<CommercialEstate>("EstateId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne<CommercialTerm>(offer => offer.Term)
            .WithOne(term => term.Offer)
            .HasForeignKey<CommercialTerm>("TermId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Navigation(offer => offer.Estate).AutoInclude();
        builder.Navigation(offer => offer.Term).AutoInclude();
    }
}

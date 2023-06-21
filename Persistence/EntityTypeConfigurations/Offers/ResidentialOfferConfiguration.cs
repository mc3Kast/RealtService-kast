using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Terms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Persistence.EntityTypeConfigurations.Offers;

public class ResidentialOfferConfiguration : IEntityTypeConfiguration<ResidentialOffer>
{
    public void Configure(EntityTypeBuilder<ResidentialOffer> builder)
    {
        builder.HasBaseType<Offer>();

        builder.HasOne<ResidentialEstate>(offer => offer.Estate)
            .WithOne(estate => estate.Offer)
            .HasForeignKey<ResidentialEstate>("EstateId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne<ResidentialTerm>(offer => offer.Term)
            .WithOne(term => term.Offer)
            .HasForeignKey<ResidentialTerm>("TermId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
